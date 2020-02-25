using System.Security.Cryptography.X509Certificates;

public class InteractibleFlorist : InteractiblePnj
{
    public ScriptablePNJ currentDialogue;
    public override void OnDialogEnded()
    {
        base.OnDialogEnded();
        if (DialogueManager.instance.lastId == 9)
        {
            dialogue = currentDialogue;
            GeneralGameManager.instance.nbFlowerBuy = 1;
        }
        if (DialogueManager.instance.lastId == 10)
        {
            dialogue = currentDialogue;
            GeneralGameManager.instance.nbFlowerBuy = 2;
        }
    }
}
