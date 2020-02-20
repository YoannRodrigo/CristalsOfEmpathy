using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleMages : InteractiblePnj
{
    public List<InteractibleMages> otherMages = new List<InteractibleMages>();

    public override void OnDialogEnded()
    {
        base.OnDialogEnded();
        foreach (InteractibleMages otherMage in otherMages)
        {
            otherMage.dialogue = otherMage.dialogueIdle;
        }
    }
}
