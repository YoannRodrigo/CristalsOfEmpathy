using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleBartender : InteractiblePnj
{
    public override void OnDialogEnded()
    {
        base.OnDialogEnded();
        if (DialogueManager.instance.lastId == 13)
        {
            GeneralGameManager.instance.hasPlayerAcceptedBartenderQuest = true;
        }
    }
}
