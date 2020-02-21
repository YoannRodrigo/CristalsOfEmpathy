#region Using Directives

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

#endregion

public class LoveEnigmaManager : MonoBehaviour
{
    #region Member Variables

    private const float TIME_BEFORE_OTHER_PERSONNAS = 1f;
    private const int NB_MAX_VICTORY = 5;

    public List<Personna> personnas = new List<Personna>();
    public List<Couple> couples = new List<Couple>();
    public Image leftPortrait;
    public Image rightPortrait;
    public Image leftPortraitDialogue;
    public Image rightPortraitDialogue;
    public TextMeshProUGUI leftName;
    public TextMeshProUGUI rightName;
    public TextMeshProUGUI leftNameDialogue;
    public TextMeshProUGUI rightNameDialogue;
    public TextMeshProUGUI leftDialogue;
    public TextMeshProUGUI rightDialogue;
    public TextMeshProUGUI tipText;
    public TextMeshProUGUI consignTitle;
    public TextMeshProUGUI gameTitle;
    public GameObject hearth;
    public Animator canvasAnimator;
    public GameObject victoryScreen;
    public GameObject loseScreen;
    public LevelChanger levelChanger;

    private int currentLeftPersonna;
    private int currentRightPersonna;
    private Couple currentCouple;
    private bool isCoupleOk;
    private float timeSinceValidation;
    private static readonly int toDialogue = Animator.StringToHash("ToDialogue");
    private static readonly int toConsigne = Animator.StringToHash("ToConsigne");
    private static readonly int toGame = Animator.StringToHash("ToGame");
    private int nbVictory;

    #endregion

    #region Methods

    private void Start()
    {
        LevelChanger.instance.FadeOut();
        AkSoundEngine.PostEvent("StartLoveMusic", gameObject);
        currentCouple = couples[0];
        ChooseRandomPersonna();
    }

    private void ChooseRandomPersonna()
    {
        hearth.SetActive(false);
        isCoupleOk = false;
        timeSinceValidation = 0;
        currentLeftPersonna = Random.Range(0, personnas.Count);
        do
        {
            currentRightPersonna = Random.Range(0, personnas.Count);
        } while (currentLeftPersonna == currentRightPersonna);

        UpdateLeftPersonna(personnas[currentLeftPersonna]);
        UpdateRightPersonna(personnas[currentRightPersonna]);
        UpdateGameTitle();
    }

    private void UpdateLeftPersonna(Personna newPersonna)
    {
        leftPortrait.sprite = newPersonna.avatarPortrait;
        leftName.text = newPersonna.name;
    }

    private void UpdateRightPersonna(Personna newPersonna)
    {
        rightPortrait.sprite = newPersonna.avatarPortrait;
        rightName.text = newPersonna.name;
    }

    private void UpdateGameTitle()
    {
        gameTitle.text = currentCouple.title;
    }

    public void LeftArrowLeftOnClic()
    {
        currentLeftPersonna--;
        if (currentLeftPersonna < 0) currentLeftPersonna = personnas.Count - 1;
        if (currentLeftPersonna == currentRightPersonna)
        {
            currentLeftPersonna--;
            if (currentLeftPersonna < 0) currentLeftPersonna = personnas.Count - 1;
        }

        UpdateLeftPersonna(personnas[currentLeftPersonna]);
    }

    public void LeftArrowRightOnClic()
    {
        currentLeftPersonna++;
        currentLeftPersonna %= personnas.Count;
        if (currentLeftPersonna == currentRightPersonna)
        {
            currentLeftPersonna++;
            currentLeftPersonna %= personnas.Count;
        }

        UpdateLeftPersonna(personnas[currentLeftPersonna]);
    }

    public void RightArrowLeftOnClic()
    {
        currentRightPersonna--;
        if (currentRightPersonna < 0) currentRightPersonna = personnas.Count - 1;
        if (currentLeftPersonna == currentRightPersonna)
        {
            currentRightPersonna--;
            if (currentRightPersonna < 0) currentRightPersonna = personnas.Count - 1;
        }

        UpdateRightPersonna(personnas[currentRightPersonna]);
    }

    public void RightArrowRightOnClic()
    {
        currentRightPersonna++;
        currentRightPersonna %= personnas.Count;
        if (currentLeftPersonna == currentRightPersonna)
        {
            currentRightPersonna++;
            currentRightPersonna %= personnas.Count;
        }

        UpdateRightPersonna(personnas[currentRightPersonna]);
    }

    public void ValidateOnClic()
    {
        if (personnas[currentLeftPersonna].couple == personnas[currentRightPersonna].couple &&
            personnas[currentLeftPersonna].couple == currentCouple.couple)
        {
            hearth.SetActive(true);
            isCoupleOk = true;
            nbVictory++;
        }
        else
        {
            loseScreen.SetActive(true);
            StartCoroutine(WaitToReturnLoveEnigma());
        }
    }

    public void DialogueOnClic()
    {
        canvasAnimator.SetBool(toDialogue, true);
        canvasAnimator.SetBool(toGame, false);
        leftPortraitDialogue.sprite = personnas[currentLeftPersonna].avatarPortrait;
        leftNameDialogue.text = personnas[currentLeftPersonna].name;
        leftDialogue.text = personnas[currentLeftPersonna].dialogues;
        rightPortraitDialogue.sprite = personnas[currentRightPersonna].avatarPortrait;
        rightNameDialogue.text = personnas[currentRightPersonna].name;
        rightDialogue.text = personnas[currentRightPersonna].dialogues;
    }

    public void ConsigneOnClic()
    {
        canvasAnimator.SetBool(toConsigne, true);
        canvasAnimator.SetBool(toGame, false);
        tipText.text = currentCouple.tip;
        consignTitle.text = currentCouple.title;
    }

    public void ToGameOnClic()
    {
        canvasAnimator.SetBool(toDialogue, false);
        canvasAnimator.SetBool(toConsigne, false);
        canvasAnimator.SetBool(toGame, true);
    }

    private void Update()
    {
        if (isCoupleOk)
        {
            timeSinceValidation += Time.deltaTime;
            if (timeSinceValidation > TIME_BEFORE_OTHER_PERSONNAS)
            {
                if (nbVictory >= NB_MAX_VICTORY)
                {
                    victoryScreen.SetActive(true);
                    StartCoroutine(WaitToReturn());
                }
                else
                {
                    Personna leftPersonna = personnas[currentLeftPersonna];
                    Personna rightPersonna = personnas[currentRightPersonna];
                    personnas.Remove(leftPersonna);
                    personnas.Remove(rightPersonna);
                    couples.Remove(currentCouple);
                    currentCouple = couples[0];
                    if (personnas.Count != 0) ChooseRandomPersonna();
                }
            }
        }
    }

    private IEnumerator WaitToReturn()
    {
        yield return new WaitForSeconds(2);
        LevelChanger.instance.ChangeToLevelWithFade(0);
    }

    private IEnumerator WaitToReturnLoveEnigma()
    {
        yield return new WaitForSeconds(2);
        LevelChanger.instance.ChangeToLevelWithFade("GuardianScreen");
    }


    #endregion
}