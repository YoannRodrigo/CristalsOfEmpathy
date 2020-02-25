using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ToMenu : MonoBehaviour
{
    private bool hasChangeSceneBegan;
    private void Update()
    {
        if (!GetComponent<VideoPlayer>().isPlaying && !hasChangeSceneBegan)
        {
            hasChangeSceneBegan = true;
            LevelChanger.instance.ChangeToLevelWithFade(0);
        }
    }
}
