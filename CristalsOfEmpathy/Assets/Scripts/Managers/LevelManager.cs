using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public List<Portal> portals;
    public int portalIndex = 0;
    private void Awake(){instance = this;}

    private void Start()
    {
        LevelChanger.instance.FadeOut();
        GeneralGameManager.instance.OnLevelLoaded();
    }

    public void SpawnPlayer()
    {
        GameObject player = Instantiate(GeneralGameManager.instance.playerPrefab, portals[portalIndex].spawn, Quaternion.identity);
        Instantiate(GeneralGameManager.instance.cameraPrefab, portals[portalIndex].spawn, Quaternion.identity).GetComponent<CameraMovement>().SetTarget(player.transform);
    }
}
