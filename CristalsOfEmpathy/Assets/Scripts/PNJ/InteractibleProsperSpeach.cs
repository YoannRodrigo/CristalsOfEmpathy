using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleProsperSpeach : InteractiblePnj
{
    public List<InteractiblePnj> otherPnjs = new List<InteractiblePnj>();
    public List<Transform> portalTransforms = new List<Transform>();

    public override void OnDialogEnded()
    {
        base.OnDialogEnded();
        foreach (InteractiblePnj otherPnj in otherPnjs)
        {
            int randId = Random.Range(0, portalTransforms.Count);
            otherPnj.npc.movement.GoThere(portalTransforms[randId].position, true);
            otherPnj.npc.movement.onDestinationReached += () =>
            {
                otherPnj.gameObject.SetActive(false);
            };
        }
        npc.movement.GoThere(portalTransforms[0].position, true);
        npc.movement.onDestinationReached += () =>
        {
            gameObject.SetActive(false);
        };
        GeneralGameManager.instance.hasPlayerHeardSpeach = true;
    }
}
