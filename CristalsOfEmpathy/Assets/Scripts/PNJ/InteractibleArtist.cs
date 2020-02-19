using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleArtist : InteractiblePnj
{
    public InteractibleArtist otherArtist;

    public override void OnDialogEnded()
    {
        base.OnDialogEnded();
        otherArtist.dialogue = otherArtist.dialogueIdle;
    }
}
