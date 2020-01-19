using System.Collections;
using TMPro;
using UnityEngine;

public class FearEnigmaManager : MonoBehaviour
{
    private const float TIME_BEETWEEN_BEAT_RISE = 1f;
    [Range(80, 180)] private float currentBeatHeart = 80;
    private bool isLastGhostSpawned;
    private bool isPlayerEnlight;
    private GameObject lastGhost;
    public LevelChanger levelChanger;
    public TextMeshProUGUI textMeshProUgui;
    private float timeSinceLastBeatRise;
    public GameObject winScreen;

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


        currentBeatHeart += (isPlayerEnlight ? -1 : 1) * Time.deltaTime;

        if (isLastGhostSpawned && !lastGhost)
        {
            winScreen.SetActive(true);
            StartCoroutine(WaitToReturn());
        }

        if (currentBeatHeart > 180) print("Dead");
    }

    private IEnumerator WaitToReturn()
    {
        yield return new WaitForSeconds(2);
        levelChanger.ChangeToLevelWithFade(0);
    }
}