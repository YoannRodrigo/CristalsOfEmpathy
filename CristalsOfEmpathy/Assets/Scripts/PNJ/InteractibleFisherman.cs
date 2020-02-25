using UnityEngine;

public class InteractibleFisherman : InteractiblePnj
{
    public ScriptablePNJ dialogueQuest;
    public GameObject boat;

    public override void OnDialogEnded()
    {
        base.OnDialogEnded();
        if (DialogueManager.instance.lastId == 16)
        {
            GeneralGameManager.instance.hasPlayerAcceptedFishermanQuest = true;
        }

        if (GeneralGameManager.instance.hasPlayerGetWoods)
        {
            GeneralGameManager.instance.isFishermanQuestFinished = true;
        }
    }

    public override void Start()
    {
        base.Start();
        if (GeneralGameManager.instance.isFishermanQuestFinished)
        {
            Destroy(boat);
            Destroy(gameObject);
        }
        else
        {
            if (GeneralGameManager.instance.hasPlayerGetWoods)
            {
                dialogue = dialogueQuest;
            }
        }
    }
}
