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
        Force();
    }

    private void Start()
    {
        if(forceOnStart) Force();
    }

    private void Force()
    {
        interactiblePnj.Speak();
        if (destroyAfter) Destroy(gameObject);
    }
}