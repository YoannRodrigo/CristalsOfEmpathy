using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPlayableCharacter : MonoBehaviour
{
    [HideInInspector] public FocusLook look;
    [HideInInspector] public AgentMovement movement;
    [HideInInspector] public Animator animator;

    [Header("References")]
    public AIPath path;

    public void Awake()
    {
        look = GetComponent<FocusLook>();
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
