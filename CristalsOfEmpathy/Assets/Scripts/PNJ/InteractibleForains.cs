using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleForains : InteractiblePnj
{
    public InteractibleForains otherForain;

    public override void OnDialogEnded()
    {
        base.OnDialogEnded();
        otherForain.dialogue = otherForain.dialogueIdle;
    }
}
