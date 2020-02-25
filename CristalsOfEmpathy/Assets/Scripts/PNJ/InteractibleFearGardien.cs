using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleFearGardien : InteractiblePnj
{
    public override void OnDialogEnded()
    {
        base.OnDialogEnded();
        if(!EndGameManager.instance.inFearBranch)
        {
            GeneralGameManager.instance.SetPortalIndex(1);
            GeneralGameManager.instance.Go("Scene_2_Manor", 3);
            EndGameManager.instance.inFearBranch = true;
        }
        else
        {
            DialogueManager.instance.gameObject.SetActive(false);
            LevelChanger.instance.ChangeToLevelWithFade("FearEnigma");
        }
    }
}
