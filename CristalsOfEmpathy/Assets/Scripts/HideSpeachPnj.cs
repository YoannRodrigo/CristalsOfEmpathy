using System.Collections.Generic;
using UnityEngine;

public class HideSpeachPnj : MonoBehaviour
{

    private void Start()
    {
        if (GeneralGameManager.instance.hasPlayerHeardSpeach)
        {
            gameObject.SetActive(false);
        }
    }
}
