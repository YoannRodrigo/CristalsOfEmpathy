using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject ghostPrefab;
    public List<Transform> spawnersTransform = new List<Transform>();
    private float timeSinceBegin;
    private readonly List<float> timeCode = new List<float>(20){6,16,20,22,24,28,37,41,44,48,50,52,60,66,72,78,84,90,96,102};
    private int ghostId;

    private void Start()
    {
        AkSoundEngine.PostEvent("StartFearMusic", gameObject);
    }
    private void Update()
    {
        timeSinceBegin += Time.deltaTime;
        if (ghostId < timeCode.Count && timeSinceBegin >= timeCode[ghostId])
        {
            switch (ghostId)
            {
                case 0 :
                    SpawnGhost(1, 7, 6);
                    break;
                case 1 : 
                case 8 :
                    SpawnGhost(1, 7, 0);
                    break;
                case 2 :
                case 3 :
                case 7 :
                    SpawnGhost(1, 7, 2);
                    break;
                case 4 :
                case 10 :
                    SpawnGhost(1, 7, 4);
                    break;
                case 5 :
                case 9 :
                    SpawnGhost(1, 7, 3);
                    break;
                case 6 :
                    SpawnGhost(1, 7, 7);
                    break;
                case 11 :
                    SpawnGhost(1, 7, 5);
                    break;
                case 12 :
                    SpawnGhost(1, 5, 1);
                    SpawnGhost(1, 5, 2);
                    SpawnGhost(1, 5, 3);
                    break;
                case 13 :
                    SpawnGhost(1, 5, 5);
                    SpawnGhost(1, 5, 6);
                    SpawnGhost(1, 5, 7);
                    break;
                case 14 :
                    SpawnGhost(1, 5, 0);
                    SpawnGhost(1, 5, 1);
                    SpawnGhost(1, 5, 7);
                    break;
                case 15 :
                    SpawnGhost(1, 5, 3);
                    SpawnGhost(1, 5, 4);
                    SpawnGhost(1, 5, 5);
                    break;
                case 16 :
                    SpawnGhost(1, 5, 1);
                    SpawnGhost(1, 5, 3);
                    SpawnGhost(1, 5, 5);
                    SpawnGhost(1, 5, 7);
                    break;
                case 17 :
                    SpawnGhost(1, 5, 0);
                    SpawnGhost(1, 5, 2);
                    SpawnGhost(1, 5, 4);
                    SpawnGhost(1, 5, 6);
                    break;
                case 18 :
                    SpawnGhost(3, 5, 2);
                    break;
                case 19 :
                    SpawnGhost(4, 5, 6);
                    break;
                
            }
        }
    }

    private void SpawnGhost(float timeBeforeDeath, float timeToReachPlayer, int spawnIndex)
    {
        GameObject ghost = Instantiate(ghostPrefab, spawnersTransform[spawnIndex].position, spawnersTransform[spawnIndex].rotation);
        ghost.GetComponent<GhostController>().SetPlayerTransform(playerTransform);
        ghost.GetComponent<GhostController>().SetDifficulty(timeBeforeDeath,timeToReachPlayer);
        ghost.SetActive(true);
        ghostId++;
    }
}
