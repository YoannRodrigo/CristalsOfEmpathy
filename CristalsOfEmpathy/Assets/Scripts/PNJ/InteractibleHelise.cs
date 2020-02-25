using UnityEngine;
public class InteractibleHelise : InteractiblePnj
{
    public override void OnDialogEnded()
    {
        base.OnDialogEnded();
        Desactivate();


        if(TutorialManager.instance != null)
        {
            TutorialManager.instance.ActivateQuest();
            
            if(npc != null)
            {
                npc.movement.SetSpeed(10f);
                npc.movement.GoThere(TutorialManager.instance.heliseRunPointAfterDialogue.position, true);
                npc.movement.onDestinationReached += () =>
                {
                    gameObject.SetActive(false);
                };
            }
        }
    }
}