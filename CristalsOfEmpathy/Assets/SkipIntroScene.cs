using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipIntroScene : MonoBehaviour
{
    public void SkipSceneOnClic()
    {
        LevelChanger.instance.ChangeToLevelWithFade(2);
    }
}
