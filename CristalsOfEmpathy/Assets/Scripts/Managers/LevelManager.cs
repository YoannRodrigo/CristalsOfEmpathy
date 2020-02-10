using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public static LevelManager instance;

    public List<Transform> spawnPoints;
    public int spawnPointIndex;
    
    
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        LevelChanger.instance.FadeOut();
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        GameObject player = Instantiate(GeneralGameManager.instance.playerPrefab,
            spawnPoints[spawnPointIndex].position,
            spawnPoints[spawnPointIndex].rotation);
        GameObject camera = Instantiate(GeneralGameManager.instance.cameraPrefab,
            spawnPoints[spawnPointIndex].position,
            spawnPoints[spawnPointIndex].rotation);
        camera.GetComponent<CameraMovement>().SetTarget(player.transform);
    }

    
    
}
