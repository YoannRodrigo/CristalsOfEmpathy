#region Using Directives
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
#endregion

public class InteractiblePotion : MonoBehaviour
{
    #region Member Variables
    public RunesCounter runesRef;

    public GameObject nextRune;
    public GameObject victoryScreen;
    public GameObject nearParticlesSystem;

    public Image rune1;
    public Image rune1Filled;

    public Image rune2;
    public Image rune2Filled;

    public Image rune3;
    public Image rune3Filled;

    public Image rune4;
    public Image rune4Filled;

    public Image rune5;
    public Image rune5Filled;

    public Image rune6;
    public Image rune6Filled;

    public LevelChanger levelChanger;
    #endregion

    #region Methods
    private void Awake()
    {
        Instantiate(nearParticlesSystem, transform);
    }
    private void Update()
    {
        TouchRotation();
    }

    private void TouchRotation()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            if (Physics.Raycast(raycast, out RaycastHit raycastHit))
            {
                if (raycastHit.collider.gameObject == gameObject && !PauseMenu.IsOnPause())
                {
                    CuriosityEnigmaProgression();
                    RunesProgression();
                }
            }
        }
    }

    public void CuriosityEnigmaProgression()
    {
        if (nextRune != null)
        {
            Destroy(this.gameObject);
            nextRune.SetActive(true);
            runesRef.runesCount++;
            Debug.Log("Object Touched");
            Debug.Log(runesRef.runesCount);
        }
    }

    public void RunesProgression()
    {
        switch (runesRef.runesCount)
        {
            case 1:
                rune1Filled.gameObject.SetActive(true);
                break;
            case 2:
                rune2Filled.gameObject.SetActive(true);
                break;
            case 3:
                rune3Filled.gameObject.SetActive(true);
                break;
            case 4:
                rune4Filled.gameObject.SetActive(true);
                break;
            case 5:
                rune5Filled.gameObject.SetActive(true);
                break;
            case 6:
                rune6Filled.gameObject.SetActive(true);
                victoryScreen.SetActive(true);
                StartCoroutine(WaitToReturn());
                break;
            default:
                break;
        }
    }

    public IEnumerator WaitToReturn()
    {
        yield return new WaitForSeconds(2);
        levelChanger.ChangeToLevelWithFade(0);
    }
    #endregion
}
