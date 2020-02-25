#region Using Directives

using System;
using UnityEngine;

#endregion

public class ForceDialogue : MonoBehaviour
{
    public bool destroyAfter;
    public bool forceOnStart;
    public InteractiblePnj interactiblePnj;
    public int textIdToBegin = 0;

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
        interactiblePnj.Speak(textIdToBegin);
        if (destroyAfter) Destroy(gameObject);
    }
}