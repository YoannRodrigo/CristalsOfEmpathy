public class InteractibleSuzie : InteractiblePnj
{
    public ScriptablePNJ dialogueQuest;
    public ScriptablePNJ dialoguePostComa;

    protected override void Update()
    {
        base.Update();
        if (GeneralGameManager.instance.nbFlowerBuy > 0)
        {
            dialogue = dialogueQuest;
        }
    }

    public override void OnDialogEnded()
    {
        if (GeneralGameManager.instance.nbFlowerBuy > 0)
        {
            GeneralGameManager.instance.nbFlowerBuy = 0;
        }
        base.OnDialogEnded();
    }
}
