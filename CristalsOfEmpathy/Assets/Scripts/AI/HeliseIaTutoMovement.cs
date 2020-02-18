
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HeliseIaTutoMovement : MonoBehaviour
{
    public Transform target;
    public Transform firstWayPoints;
    public List<Transform> waypoints = new List<Transform>();
    private int nextWayPointId;
    private NavMeshAgent agent;
    private bool isAllowToMove;
    // Start is called before the first frame update
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void AllowHeliseToMove()
    {
        isAllowToMove = true;
    }
    
    // Update is called once per frame
    private void Update()
    {
        if(firstWayPoints == null)
        {
            InitFirstWayPoint();
        }
        if(isAllowToMove)
        {
            Move();
        }
    }

    private void InitFirstWayPoint()
    {
        firstWayPoints = FindObjectOfType<PlayerMovement>().transform;
        waypoints.Add(waypoints[0]);
        waypoints[0] = firstWayPoints;
        if (firstWayPoints != null)
        {
            nextWayPointId = 0;
        }
    }

    private void Move()
    {
        if (firstWayPoints != null)
        {
            Vector3 position = transform.position;
            Vector3 position1 = waypoints[nextWayPointId].transform.position;
            Debug.DrawLine(position, position1,Color.blue);
            agent.SetDestination(position1);
        }
        if (target != null)
        {
            Vector3 position = transform.position;
            Vector3 position1 = target.transform.position;
            Debug.DrawLine(position, position1,Color.blue);
            agent.SetDestination(position1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == waypoints[nextWayPointId].gameObject.name && nextWayPointId < waypoints.Count - 1)
        {
            nextWayPointId++;
        }
    }
}

