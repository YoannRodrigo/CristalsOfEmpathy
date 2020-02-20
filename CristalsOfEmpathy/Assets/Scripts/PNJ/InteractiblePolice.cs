using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiblePolice : InteractiblePnj
{
    public InteractiblePolice otherPolice;

    public override void OnDialogEnded()
    {
        base.OnDialogEnded();
        otherPolice.dialogue = otherPolice.dialogueIdle;
    }
}
