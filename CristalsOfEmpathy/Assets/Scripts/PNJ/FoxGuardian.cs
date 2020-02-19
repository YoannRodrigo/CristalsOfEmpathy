using UnityEngine;

public class FoxGuardian : InteractiblePnj
{
    public AgentMovement movement;
    public Transform pointToGoAfter;

    public override void Start()
    {
        base.Start();
        if(movement != null) movement.animator = gameObject.GetComponentInChildren<Animator>();
    }

    public override void OnDialogEnded()
    {
        base.OnDialogEnded();

        if(movement == null || pointToGoAfter == null) 
        {
            Debug.Log("Fox isn't set properly, exterminating it.");
            Destroy(gameObject);
            return;
        }

        movement.GoThere(pointToGoAfter.position);
        movement.onDestinationReached += () => {Destroy(gameObject);};
    }

}