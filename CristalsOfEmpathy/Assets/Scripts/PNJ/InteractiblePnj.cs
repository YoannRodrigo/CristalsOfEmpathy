#region Using Directives

using System;
using UnityEngine;

#endregion

public class InteractiblePnj : InteractibleItem
{
    public ScriptablePNJ dialogue;

    protected override void OnTouch()
    {
        Speak();
    }

    public void Speak()
    {
        if(dialogue != null) 
        {
            DialogueManager.instance.Initialize(dialogue, 0, () => {this.OnDialogEnded();});
        }
    }

    public virtual void OnDialogEnded(){}
}