using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleAlberthus : InteractiblePnj
{
    protected override void OnTouch()
    {
        base.OnTouch();
        GeneralGameManager.instance.hasPlayerMetAlberthus = true;
    }
}
