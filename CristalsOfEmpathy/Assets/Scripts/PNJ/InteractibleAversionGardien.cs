using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleAversionGardien : InteractiblePnj
{
    public override void OnDialogEnded()
    {
        base.OnDialogEnded();
        if(!EndGameManager.instance.inAversionBranch)
        {
        }
        else
        {
            DialogueManager.instance.gameObject.SetActive(false);
            LevelChanger.instance.ChangeToLevelWithFade("AversionEnigma");
        }
    }
}
