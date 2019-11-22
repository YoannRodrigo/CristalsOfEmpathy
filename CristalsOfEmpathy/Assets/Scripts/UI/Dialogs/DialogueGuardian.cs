#region Using Directives
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#endregion

public class DialogueGuardian : MonoBehaviour
{
    #region Member Variables
    public BarPointsHandler barPointsHandler;
    public TutorialManager tutorialManager;

    public Text pnjNameTextGuardian;
    public Text dialogueTextGuardian;
    public Text answer1Guardian;
    public Text answer2Guardian;
    public Text answer3Guardian;
    public Text answer4Guardian;

    public GameObject dialogueBox;
    public GameObject answerBox;
    public GameObject joystick;
    public GameObject pauseButton;
    public GameObject inventoryButton;
    public GameObject guardian;

    private int currentTextIdGuardian;
    private int currentAnswerIdGuardian;
    private bool isTextWrittenGuardian;
    public bool isDialogueEndedGuardian;
    private readonly List<Dialogue> dialoguesGuardian = new List<Dialogue>();
    private readonly List<PlayerAnswers> playerAnswersGuardian = new List<PlayerAnswers>();
    #endregion

    #region Methods
    private void Start()
    {
        guardian = GameObject.FindGameObjectWithTag("Guardian");
    }

    private void Update()
    {
        if (isDialogueEndedGuardian)
        {
            if (guardian != null)
            {
                guardian.transform.position -= new Vector3(2f * Time.deltaTime, 0, 0);
                Destroy(guardian.gameObject, 22f);
            }
        }
    }

    public void StartDialogueGuardian(Dialogue[] dialoguesGuardian, int startId = 0)
    {
        if (tutorialManager.isQuestActivated)
        {
            OnDialogueInteractionGuardian(dialoguesGuardian);
            DisplayNextSentenceGuardian(startId);
        }
        else
        {
            OnDialogueInteractionGuardian(dialoguesGuardian);
        }
        
    }


    public void StartDialogueGuardian(Dialogue[] dialoguesGuardian, PlayerAnswers[] playerAnswersGuardian, int startId = 0)
    {
        this.playerAnswersGuardian.Clear();
        foreach (PlayerAnswers playerAnswer in playerAnswersGuardian)
        {
            this.playerAnswersGuardian.Add(playerAnswer);
        }
        StartDialogueGuardian(dialoguesGuardian, startId);
    }

    public void OnDialogueInteractionGuardian(Dialogue[] dialoguesGuardian, int startId = 0)
    {
        joystick.SetActive(false);
        pauseButton.SetActive(false);
        inventoryButton.SetActive(false);
        this.dialoguesGuardian.Clear();
        foreach (Dialogue dialogue in dialoguesGuardian)
        {
            this.dialoguesGuardian.Add(dialogue);
        }
    }

    public void EndDialogueGuardian()
    {
        dialogueBox.SetActive(false);
        joystick.SetActive(true);
        pauseButton.SetActive(true);
        inventoryButton.SetActive(true);

        if (pnjNameTextGuardian.text == "Guardian")
        {
            isDialogueEndedGuardian = true;
        }
    }

    public void DisplayNextSentenceGuardian(int id)
    {
        currentTextIdGuardian = id;
        pnjNameTextGuardian.text = dialoguesGuardian[id].pnjName;

        StopAllCoroutines();
    }

    public void DisplayAnswer(int id)
    {
        currentAnswerIdGuardian = id;
        answer1Guardian.text = playerAnswersGuardian[id].text1;
        answer2Guardian.text = playerAnswersGuardian[id].text2;
        answer3Guardian.text = playerAnswersGuardian[id].text3;
        answer4Guardian.text = playerAnswersGuardian[id].text4;
    }

    public void NextSentenceOnClickGuardian()
    {
        if (!isTextWrittenGuardian)
        {
            isTextWrittenGuardian = true;
        }
        else
        {
            isTextWrittenGuardian = false;
            if (dialoguesGuardian[currentTextIdGuardian].isAnswerNeeded)
            {
                dialogueBox.SetActive(false);
                answerBox.SetActive(true);
                DisplayAnswer(dialoguesGuardian[currentTextIdGuardian].nextTextId);
            }

            else
            {
                if (dialoguesGuardian[currentTextIdGuardian].nextTextId == -1)
                {
                    EndDialogueGuardian();
                }

                else
                {
                    DisplayNextSentenceGuardian(dialoguesGuardian[currentTextIdGuardian].nextTextId);
                }
            }
        }
    }

    public void Answer1OnClickGuardian()
    {
        dialogueBox.SetActive(true);
        answerBox.SetActive(false);
        DisplayNextSentenceGuardian(playerAnswersGuardian[currentAnswerIdGuardian].nextTextId1);

        barPointsHandler.LoveBarPoints += 10;
    }

    public void Answer2OnClickGuardian()
    {
        dialogueBox.SetActive(true);
        answerBox.SetActive(false);
        DisplayNextSentenceGuardian(playerAnswersGuardian[currentAnswerIdGuardian].nextTextId2);

        barPointsHandler.CuriosityBarPoints += 10;
    }

    public void Answer3OnClickGuardian()
    {
        dialogueBox.SetActive(true);
        answerBox.SetActive(false);
        DisplayNextSentenceGuardian(playerAnswersGuardian[currentAnswerIdGuardian].nextTextId3);

        barPointsHandler.FearBarPoints += 10;
    }

    public void Answer4OnClickGuardian()
    {
        dialogueBox.SetActive(true);
        answerBox.SetActive(false);
        DisplayNextSentenceGuardian(playerAnswersGuardian[currentAnswerIdGuardian].nextTextId4);

        barPointsHandler.AversionBarPoints += 10;
    }
    #endregion
}