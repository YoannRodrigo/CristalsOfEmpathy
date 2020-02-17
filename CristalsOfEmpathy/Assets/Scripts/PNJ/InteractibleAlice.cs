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
}
