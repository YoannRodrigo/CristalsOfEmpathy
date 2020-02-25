using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheatEnigma : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            BarPointsHandler.UpdateEmotionPoints(BarPointsHandler.Emotions.FEAR,100);
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            BarPointsHandler.UpdateEmotionPoints(BarPointsHandler.Emotions.LOVE,100);
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            BarPointsHandler.UpdateEmotionPoints(BarPointsHandler.Emotions.AVERSION,100);
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            BarPointsHandler.UpdateEmotionPoints(BarPointsHandler.Emotions.CURIOSITY,100);
        }
    }
}
