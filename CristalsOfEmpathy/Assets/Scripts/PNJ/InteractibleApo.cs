using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleApo : InteractiblePnj
{
    public override void OnDialogEnded()
    {
        base.OnDialogEnded();
        if (DialogueManager.instance.lastId == 11)
        {
            GeneralGameManager.instance.hasPlayerAcceptedApoQuest = true;
        }
    }
}
