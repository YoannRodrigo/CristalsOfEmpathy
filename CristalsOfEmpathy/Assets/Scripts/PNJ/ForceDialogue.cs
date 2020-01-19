﻿#region Using Directives

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

    #endregion

    #region Member Variables

    public bool isNeededToBeDestroyed;
    public InteractiblePnj interactiblePnj;
    public int dialogueToPlay;

    #endregion
}