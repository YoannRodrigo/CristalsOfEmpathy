using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private readonly List<float> timeCode = new List<float>(20)
        {6, 16, 20, 22, 24, 28, 37, 41, 44, 48, 50, 52, 60, 66, 72, 78, 84, 90, 96, 102};

    public Light ambiantLight;
    public FearEnigmaManager fearEnigmaManager;
    private int ghostId;
    public GameObject ghostPrefab;
    private bool isMusicPlaying;
    private GameObject lastGhost;
    public Transform playerTransform;
    public List<Transform> spawnersTransform = new List<Transform>();
    private float timeSinceBegin;

    private void StartMusic()
    {
        if (!isMusicPlaying)
        {
            isMusicPlaying = true;
            AkSoundEngine.PostEvent("StartFearMusic", gameObject);
        }
    }

    private void Update()
    {
        if (ambiantLight.intensity > 0)
        {
            ambiantLight.intensity -= Time.deltaTime;
        }
        else
        {
            StartMusic();
            timeSinceBegin += Time.deltaTime;
            if (ghostId < timeCode.Count && timeSinceBegin >= timeCode[ghostId]) SpawnGhost();
        }
    }

    private GameObject SpawnAGhost(float timeBeforeDeath, float timeToReachPlayer, int spawnIndex)
    {
        GameObject ghost = Instantiate(ghostPrefab, spawnersTransform[spawnIndex].position,
            spawnersTransform[spawnIndex].rotation);
        ghost.GetComponent<GhostController>().SetPlayerTransform(playerTransform);
        ghost.GetComponent<GhostController>().SetDifficulty(timeBeforeDeath, timeToReachPlayer);
        ghost.SetActive(true);
        ghostId++;
        return ghost;
    }

    private void SpawnGhost()
    {
        switch (ghostId)
        {
            case 0:
                SpawnAGhost(1, 7, 6);
                break;
            case 1:
            case 8:
                SpawnAGhost(1, 7, 0);
                break;
            case 2:
            case 3:
            case 7:
                SpawnAGhost(1, 7, 2);
                break;
            case 4:
            case 10:
                SpawnAGhost(1, 7, 4);
                break;
            case 5:
            case 9:
                SpawnAGhost(1, 7, 3);
                break;
            case 6:
                SpawnAGhost(1, 7, 7);
                break;
            case 11:
                SpawnAGhost(1, 7, 5);
                break;
            case 12:
                SpawnAGhost(1, 5, 1);
                SpawnAGhost(1, 5, 2);
                SpawnAGhost(1, 5, 3);
                break;
            case 13:
                SpawnAGhost(1, 5, 5);
                SpawnAGhost(1, 5, 6);
                SpawnAGhost(1, 5, 7);
                break;
            case 14:
                SpawnAGhost(1, 5, 0);
                SpawnAGhost(1, 5, 1);
                SpawnAGhost(1, 5, 7);
                break;
            case 15:
                SpawnAGhost(1, 5, 3);
                SpawnAGhost(1, 5, 4);
                SpawnAGhost(1, 5, 5);
                break;
            case 16:
                SpawnAGhost(1, 5, 1);
                SpawnAGhost(1, 5, 3);
                SpawnAGhost(1, 5, 5);
                SpawnAGhost(1, 5, 7);
                break;
            case 17:
                SpawnAGhost(1, 5, 0);
                SpawnAGhost(1, 5, 2);
                SpawnAGhost(1, 5, 4);
                SpawnAGhost(1, 5, 6);
                break;
            case 18:
                SpawnAGhost(3, 5, 2);
                break;
            case 19:
                lastGhost = SpawnAGhost(4, 5, 6);
                lastGhost.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
                fearEnigmaManager.SetLastGhost(lastGhost);
                break;
        }
    }
}