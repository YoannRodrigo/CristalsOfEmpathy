using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleForains : InteractiblePnj
{
    public ScriptablePNJ dialogueQuest;
    public InteractibleForains otherForain;

    public override void OnDialogEnded()
    {
        base.OnDialogEnded();
        otherForain.dialogue = otherForain.dialogueIdle;
        if (GeneralGameManager.instance.hasPlayerAcceptedBartenderQuest)
        {
            GeneralGameManager.instance.isBartenderQuestFinished = true;
        }
    }

    public override void Start()
    {
        base.Start();
        if (GeneralGameManager.instance.hasPlayerAcceptedBartenderQuest &&
            !GeneralGameManager.instance.isBartenderQuestFinished)
        {
            dialogue = dialogueQuest;
            otherForain.dialogue = otherForain.dialogueQuest;
        }
    }
}
