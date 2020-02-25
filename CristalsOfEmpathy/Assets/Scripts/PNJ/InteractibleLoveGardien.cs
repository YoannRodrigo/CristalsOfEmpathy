using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleLoveGardien : InteractiblePnj
{
    public override void OnDialogEnded()
    {
        base.OnDialogEnded();
        if(!EndGameManager.instance.inLoveBranch)
        {
            EndGameManager.instance.inLoveBranch = true;
        }
        else
        {
            DialogueManager.instance.gameObject.SetActive(false);
            LevelChanger.instance.ChangeToLevelWithFade("LoveEnigma");
        }
    }
}
