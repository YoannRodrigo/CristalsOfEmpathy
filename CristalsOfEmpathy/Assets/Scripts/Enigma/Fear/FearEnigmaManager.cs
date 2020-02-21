using System.Collections;
using TMPro;
using UnityEngine;

public class FearEnigmaManager : MonoBehaviour
{
    [Range(80, 180)] private float currentBeatHeart = 80;
    private bool isLastGhostSpawned;
    private bool isPlayerEnlight;
    private GameObject lastGhost;
    public LevelChanger levelChanger;
    public TextMeshProUGUI textMeshProUgui;
    private float timeSinceLastBeatRise;
    public GameObject winScreen;
    public GameObject loseScreen;

    private void Start()
    {
        LevelChanger.instance.FadeOut();
    }
    
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
        currentBeatHeart += (isPlayerEnlight ? -1 : 1) * Time.deltaTime;
        
        if (currentBeatHeart < 80)
        {
            currentBeatHeart = 80;
        }
        
        if (isLastGhostSpawned && !lastGhost)
        {
            winScreen.SetActive(true);
            StartCoroutine(WaitToReturn());
        }

        if (currentBeatHeart > 180)
        {
            Death();
        }
    }

    public void Death()
    {
        loseScreen.SetActive(true);
        StartCoroutine(WaitToReturnFearEnigma());
    }
    private IEnumerator WaitToReturn()
    {
        yield return new WaitForSeconds(2);
        LevelChanger.instance.ChangeToLevelWithFade("CreditScene");
    }

    private IEnumerator WaitToReturnFearEnigma()
    {
        yield return new WaitForSeconds(2);
        LevelChanger.instance.ChangeToLevelWithFade("GuardianScreen");
    }
}