using UnityEngine;
using UnityEngine.Video;

public class ToIntroGame : MonoBehaviour
{
    public VideoPlayer videoIntro;
    private bool isChangeSceneBegan;

    private void Update()
    {
        if (!videoIntro.isPlaying && !isChangeSceneBegan)
        {
            isChangeSceneBegan = true;
            LevelChanger.instance.ChangeToLevelWithFade("Scene_0_Tuto");
        }
    }
}
