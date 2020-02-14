using UnityEngine;
public class NonPlayableCharacter : MonoBehaviour
{
    [HideInInspector] public FocusLook look;
    [HideInInspector] public AgentMovement movement;
    [HideInInspector] public Animator animator;
    [HideInInspector] public Face face;

    [Header("References")]
    public AIPath path;

    public void Awake()
    {
        look = GetComponent<FocusLook>();
        movement = GetComponent<AgentMovement>();
        animator = GetComponentInChildren<Animator>();
        face = GetComponentInChildren<Face>();
    }

    public void Start()
    {
        if(path != null) movement.FollowPath(path);
        if(animator != null) movement.animator = animator;
    }

    public void Update()
    {
        movement.Tick();
    }

    public void Speak()
    {
        if(face != null) face.Speak();
    }

    public void ShutUp()
    {
        if(face != null) face.ShutUp();
    }
}
