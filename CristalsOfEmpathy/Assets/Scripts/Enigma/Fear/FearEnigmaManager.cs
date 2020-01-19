using System.Collections;
using TMPro;
using UnityEngine;

public class FearEnigmaManager : MonoBehaviour
{
    [Range(80,180)] private float currentBeatHeart = 80;
    private const float TIME_BEETWEEN_BEAT_RISE = 1f;
    private float timeSinceLastBeatRise;
    public TextMeshProUGUI textMeshProUgui;
    public GameObject winScreen;
    public LevelChanger levelChanger;
    private GameObject lastGhost;
    private bool isLastGhostSpawned;
    private bool isPlayerEnlight;

    public void SetLastGhost(GameObject lastGhost)
    {
        this.lastGhost = lastGhost;
        isLastGhostSpawned = true;
    }

    public void SetPlayerEnlight(bool isPlayerEnlight)
    {
        this.isPlayerEnlight = isPlayerEnlight;
    }
    
    private void Update()
    {
        textMeshProUgui.text = "" + Mathf.Floor(currentBeatHeart);
        timeSinceLastBeatRise += Time.deltaTime;
        
        
        currentBeatHeart += (isPlayerEnlight ? -1 :1) * Time.deltaTime;

        if (isLastGhostSpawned && !lastGhost)
        {
            winScreen.SetActive(true);
            StartCoroutine(waitToReturn());
        }
        
        if (currentBeatHeart > 180)
        {
            print("Dead");
        }
    }
    
    private IEnumerator waitToReturn()
    {
        yield return new WaitForSeconds(2);
        levelChanger.ChangeToLevelWithFade(0);
    }
}
