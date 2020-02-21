using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleForains : InteractiblePnj
{
    public ScriptablePNJ dialogueQuest;
    public ScriptablePNJ dialogueAversion;
    public InteractibleForains otherForain;

    public override void OnDialogEnded()
    {
        base.OnDialogEnded();
        otherForain.dialogue = otherForain.dialogueIdle;
        if (GeneralGameManager.instance.hasPlayerAcceptedBartenderQuest)
        {
            GeneralGameManager.instance.isBartenderQuestFinished = true;
        }
        if (EndGameManager.instance.inAversionBranch)
        {
            LevelChanger.instance.ChangeToLevelWithFade("GuardianScene");
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
        if (EndGameManager.instance.inAversionBranch)
        {
            dialogue = dialogueAversion;
            otherForain.dialogue = otherForain.dialogueAversion;
        }
    }
}
