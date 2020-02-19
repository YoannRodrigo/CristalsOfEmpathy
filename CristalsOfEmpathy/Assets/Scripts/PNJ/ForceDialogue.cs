#region Using Directives

using System;
using UnityEngine;

#endregion

public class ForceDialogue : MonoBehaviour
{
    
    #region Methods

    private void OnTriggerEnter(Collider other)
    {
        interactiblePnj.StartDialogue(dialogueToPlay);
        if (isNeededToBeDestroyed) Destroy(gameObject);
    }

    private void Start()
    {
        if(forceOnStart) interactiblePnj.StartDialogue(dialogueToPlay);
    }

    #endregion

    #region Member Variables

    public bool isNeededToBeDestroyed;
    public bool forceOnStart;
    public InteractiblePnj interactiblePnj;
    public int dialogueToPlay;

    #endregion
}