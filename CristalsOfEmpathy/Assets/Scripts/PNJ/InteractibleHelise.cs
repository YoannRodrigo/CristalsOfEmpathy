using UnityEngine;

public class InteractibleHelise : InteractiblePnj
{
    bool following;

    public override void OnDialogEnded()
    {
        base.OnDialogEnded();
        following = true;
        Desactivate();
    }

    public void Update()
    {
        if(following)
        {
            Vector3 pos = LevelManager.instance.player.transform.position + LevelManager.instance.player.transform.right * 3f;
            npc.movement.GoThere(pos);
        }
    }
}