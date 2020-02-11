using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPlayableCharacter : MonoBehaviour
{
    private AgentMovement movement;
    private Animator animator;
    public AIPath path;

    public void Awake()
    {
        movement = GetComponent<AgentMovement>();
        animator = GetComponentInChildren<Animator>();
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
}
