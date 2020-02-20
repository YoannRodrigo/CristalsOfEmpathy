
public class InteractibleWoods : InteractiblePnj
{
    public override void OnDialogEnded()
    {
        base.OnDialogEnded();
        GeneralGameManager.instance.hasPlayerGetWoods = true;
    }
}
