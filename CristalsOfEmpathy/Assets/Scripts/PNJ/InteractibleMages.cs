using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleMages : InteractiblePnj
{
    public ScriptablePNJ dialogueQuest;
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
