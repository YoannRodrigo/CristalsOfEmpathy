using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleMages : InteractiblePnj
{
    public ScriptablePNJ dialogueQuest;
    public ScriptablePNJ dialogueAmour;
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
    }

    public override void OnDialogEnded()
    {
        base.OnDialogEnded();
        if (GeneralGameManager.instance.hasPlayerAcceptedApoQuest)
        {
            GeneralGameManager.instance.isApoQuestFinished = true;
        }
    }
}
