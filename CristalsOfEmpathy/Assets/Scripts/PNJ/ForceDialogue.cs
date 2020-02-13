#region Using Directives

using System;
using UnityEngine;

#endregion

public class ForceDialogue : MonoBehaviour
{
    public bool destroyAfter;
    public bool forceOnStart;
    public InteractiblePnj interactiblePnj;

    private void OnTriggerEnter(Collider other)
    {
        interactiblePnj.Speak();
        if (destroyAfter) Destroy(gameObject);
    }

    private void Start()
    {
        if(forceOnStart) interactiblePnj.Speak();
    }
}