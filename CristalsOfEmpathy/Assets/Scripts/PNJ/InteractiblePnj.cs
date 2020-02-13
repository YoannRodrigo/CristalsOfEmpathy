﻿#if UNITY_EDITOR
    using UnityEditor;
#endif
using System;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class InteractiblePnj : InteractibleItem
{
    public ScriptablePNJ dialogue;
    private NonPlayableCharacter npc;

    public override void Start()
    {
        base.Start();
        npc = GetComponent<NonPlayableCharacter>();
    }

    protected override void OnTouch()
    {
        Speak();
    }

    public void Speak()
    {
        if(dialogue != null) 
        {
            bool success = DialogueManager.instance.Initialize(dialogue, 0, () => {this.OnDialogEnded();});
            if(success) LookAtPlayerOfTheLevel();
        }
    }

    public void LookAtPlayerOfTheLevel()
    {
        if(npc != null)
        {
            npc.movement.Stop();
            npc.transform.forward = -(npc.transform.position - LevelManager.instance.player.transform.position).normalized;
            LevelManager.instance.player.OrientTowards(npc.transform.position);
            LevelManager.instance.player.Freeze();
        }
    }

    public virtual void OnDialogEnded()
    {
        LevelManager.instance.player.UnFreeze();
        if(npc != null && npc.path != null) npc.movement.FollowPath(npc.path);
    }

    protected override void Enter()
    {
        base.Enter();
        if(npc != null)
        {
            LevelManager.instance.player.look.FocusOn(npc.look.head);
            npc.look.FocusOn(LevelManager.instance.player.look.head.transform);
        }
    }
    protected override void Exit()
    {
        base.Exit();
        if(npc != null)
        {
            npc.look.LooseFocus();
        }
    }
#if UNITY_EDITOR
    public override void OnDrawGizmos()
    {  
        GUI.skin.label.normal.textColor = new Color32(255, 255, 255, 255);
        if(dialogue != null)
        {
            base.OnDrawGizmos();
            Handles.Label(transform.position, dialogue.name);
        }
        else
        {
            Handles.Label(transform.position, "No Dialogue assigned");
        }

    }
#endif
}