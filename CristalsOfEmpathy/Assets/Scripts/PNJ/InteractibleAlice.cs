using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleAlice : InteractiblePnj
{
    protected override void OnTouch()
    {
        base.OnTouch();
        GeneralGameManager.instance.hasPlayerMetAlice = true;
    }

    public override void Start()
    {
        base.Start();
        if (GeneralGameManager.instance.hasPlayerMetAlice)
        {
            dialogue = dialogueIdle;
        }
    }
}
