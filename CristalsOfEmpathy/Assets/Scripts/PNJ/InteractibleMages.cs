using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleMages : InteractiblePnj
{
    public ScriptablePNJ dialogueQuest;
    public ScriptablePNJ dialogueAmour;
    public ScriptablePNJ dialogueCuriosity;
    public List<InteractibleMages> otherMages = new List<InteractibleMages>();

    public override void Start()
    {
        base.Start();
        if (!GeneralGameManager.instance.isApoQuestFinished && GeneralGameManager.instance.hasPlayerAcceptedApoQuest)
        {
            dialogue = dialogueQuest;
            foreach (InteractibleMages otherMage in otherMages)
            {
                otherMage.dialogue = otherMage.dialogueQuest;
            }
        }

        if (EndGameManager.instance.inLoveBranch)
        {
            dialogue = dialogueAmour;
            foreach (InteractibleMages otherMage in otherMages)
            {
                otherMage.dialogue = otherMage.dialogueAmour;
            }
        }
        if (EndGameManager.instance.inCuriosityBranch)
        {
            dialogue = dialogueCuriosity;
            foreach (InteractibleMages otherMage in otherMages)
            {
                otherMage.dialogue = otherMage.dialogueCuriosity;
            }
        }
    }

    public override void OnDialogEnded()
    {
        base.OnDialogEnded();
        if (GeneralGameManager.instance.hasPlayerAcceptedApoQuest)
        {
            GeneralGameManager.instance.isApoQuestFinished = true;
        }
        if (EndGameManager.instance.inLoveBranch)
        {
            EndGameManager.instance.hasPlayerMeetMages = true;
        }
        if (EndGameManager.instance.inCuriosityBranch)
        {
            LevelChanger.instance.ChangeToLevelWithFade("GuardianScene");
        }
    }
}
