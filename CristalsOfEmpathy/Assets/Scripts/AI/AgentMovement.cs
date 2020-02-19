using UnityEngine;
using UnityEngine.AI;
#if UNITY_EDITOR
using UnityEditor;
#endif

[RequireComponent(typeof(NavMeshAgent))]
public class AgentMovement : MonoBehaviour
{
    [Header("Settings")]
    public float speed = 5f;
    public float navTreshold = 1f;
	public float animatorRunSpeed = 1f;

	[HideInInspector] public bool going = false;
    [HideInInspector] public bool reached = false;
    [HideInInspector] public Animator animator;
	public System.Action onDestinationReached;
	public System.Action onPathCompleted;
	public System.Action onTargetOffPath;
    private Transform chaseTarget;
	private NavMeshAgent agent;
    private AIPath path;
	private bool followingPath;
    private int currentIndexOnPath;

	public void ClearEvents()
    {
        onDestinationReached = null;
        onPathCompleted = null;
        onTargetOffPath = null;
    }

    public void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        going = false;
        SetSpeed(speed);
    }

    public void FollowPath(AIPath newPath)
    {
		if (newPath == null) return;
        path = newPath;
        currentIndexOnPath = Random.Range(0, path.points.Count);
        followingPath = true;
        ClearEvents();
        onPathCompleted += () => {if(!path.loop) followingPath = false;};
        StopChase();
        GoAtPoint(currentIndexOnPath);
    }
    public void StopFollowingPath()
    {
        followingPath = false;
    }

    public void Update()
    {
        Tick();
    }

	public void ResetSpeed()
    {
        SetSpeed(speed);
    }

    public void SetSpeed(float value)
    {
        if(value < 0) value = 0f;
        agent.speed = value;
    }
    
    public void Chase(Transform target)
    {
		ClearEvents();
		StopFollowingPath();
		chaseTarget = target;
    }

    public void Clear()
    {
        reached = false;
        going = false;
        chaseTarget = null;
    }

    public bool GoThere(Vector3 pos, bool clearEvents = false)
    {
        if(clearEvents) ClearEvents();

        NavMeshPath path = new NavMeshPath();
        agent.CalculatePath(pos, path);
        if(path.status == NavMeshPathStatus.PathPartial
        || path.status == NavMeshPathStatus.PathInvalid)
        {
			return false;
        }
        else 
        {
			agent.SetDestination(pos);
            going = true;
            reached = false;
            return true;
        }
    }

	public void Tick()
    {
		if (reached) reached = false;
		if (DestinationReached())
        {
            reached = true;
            going = false;
            if(onDestinationReached != null)
            {
                onDestinationReached.Invoke();
                onDestinationReached = null;
            }

            if(path != null && currentIndexOnPath == path.points.Count - 1)
            {
                if(onPathCompleted != null)
                {
                    onPathCompleted.Invoke();
                    onPathCompleted = null;
                }
            }

            if(followingPath) GoToNextPoint();
        }
        else
        {
            if(chaseTarget != null)
            {
                if(!GoThere(chaseTarget.transform.position))
                {
                    if(onTargetOffPath != null)
                    {
                        onTargetOffPath.Invoke();
                        onTargetOffPath = null;
                    }
                }
            }
        }

        if(animator) 
        {
            animator.SetFloat("Speed", agent.velocity.magnitude/animatorRunSpeed);
        }
    }

    public bool GoAtPoint(int index)
    {
        if(path.points.Count == 0
        || index < 0
        || index >= path.points.Count) return false;

        if(GoThere(path.GetPosition(index)))
        {
            currentIndexOnPath = index;
            return true;
        }
        else return false;
    }

    public void StopChase()
    {
        chaseTarget = null;
    }

    public void Stop()
    {
        going = false;
        reached = false;
        chaseTarget = null;
        StopFollowingPath();
        agent.SetDestination(transform.position);
    }

    public bool GoToNextPoint()
    {
        return GoAtPoint(GetNextPointIndex());
    }

    public int GetNextPointIndex()
    {
        int waypoint = currentIndexOnPath + 1;
        if(waypoint >= path.points.Count) waypoint = 0;
        return waypoint;
    }

    float DistanceToDestination()
    {
        return Vector3.Distance(transform.position, agent.destination);
    }

    bool DestinationReached()
    {
        return going && DistanceToDestination() < navTreshold;
    }

    
#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        Gizmos.color = new Color32(255, 215, 0, 255);
        if(EditorApplication.isPlaying && agent != null && agent.destination != null)
        {
            UnityEditor.Handles.DrawLine(transform.position, agent.destination);
        }
    }
#endif

}
