using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleGardener : InteractiblePnj
{
    protected override void OnTouch()
    {
        base.OnTouch();
        GeneralGameManager.instance.hasPlayerMetGarderner = true;
    }
}
