using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerForains : MonoBehaviour
{
    private void Start()
    {
        AkSoundEngine.PostEvent("Forains", gameObject);
    }
}
