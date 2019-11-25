#region Using Directives
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#endregion

public class DialogueManager : MonoBehaviour
{
    #region Member Variables
    public TutorialManager tutorialManager;

    public Text pnjNameText;
    public Text dialogueText;
    public Text answer1;
    public Text answer2;
    public Text answer3;
    public Text answer4;

    public GameObject dialogueBox;
    public GameObject answerBox;
    public GameObject joystick;
    public GameObject pauseButton;
    public GameObject inventoryButton;

    private int currentTextId;
    private int currentAnswerId;
    private bool isTextWritten;
    public List<Dialogue> dialogues = new List<Dialogue>();
    public List<PlayerAnswers> playerAnswers = new List<PlayerAnswers>();
    #endregion

    #region Methods

    public void StartDialogue(Dialogue[] dialogues, int startId = 0)
    {
        // QUEST LOCKING DIALOG & FIXING SHIT
        
        dialogueBox.SetActive(true);
        OnDialogueInteraction(dialogues);
        DisplayNextSentence(startId);
        // SAMPLE DIALOG WHEN QUEST ACHIEVED & FIXING SHIT
        /*if (tutorialManager.isQuestAchieved)
        {
            OnDialogueInteraction(dialogues);
            DisplayNextSentence(8);
            tutorialManager.isQuestSubmitted = true;
        }*/
    }

    public void StartDialogue(Dialogue[] dialogues, PlayerAnswers[] playerAnswers, int startId = 0)
    {
        foreach (PlayerAnswers playerAnswer in playerAnswers)
        {
            this.playerAnswers.Add(playerAnswer);
        }
        StartDialogue(dialogues, startId);
    }

    public void OnDialogueInteraction(Dialogue[] dialogues)
    {
        joystick.SetActive(false);
        pauseButton.SetActive(false);
        inventoryButton.SetActive(false);
        foreach (Dialogue dialogue in dialogues)
        {
            this.dialogues.Add(dialogue);
        }
    }

    public void EndDialogue()
    {
        ResetVariables();
        ActivateGameUi();
    }

    private void ResetVariables()
    {
        currentAnswerId = 0;
        currentTextId = 0;
        isTextWritten = false;
        dialogues.Clear();
        playerAnswers.Clear();
        dialogueText.text = "";
        pnjNameText.text = "";
    }

    private void ActivateGameUi()
    {
        dialogueBox.SetActive(false);
        joystick.SetActive(true);
        pauseButton.SetActive(true);
        inventoryButton.SetActive(true);
    }

    public void DisplayNextSentence(int id)
    {
        currentTextId = id;
        pnjNameText.text = dialogues[id].pnjName;

        StopAllCoroutines();
        StartCoroutine(TypeSentence(dialogues[id].sentence));
    }

    public void DisplayAnswer(int id)
    {
        currentAnswerId = id;
        answer1.text = playerAnswers[id].text1;
        answer2.text = playerAnswers[id].text2;
        answer3.text = playerAnswers[id].text3;
        answer4.text = playerAnswers[id].text4;
    }

    public void NextSentenceOnClick()
    {
        if (!isTextWritten)
        {
            isTextWritten = true;
        }
        else
        {
            isTextWritten = false;
            if (dialogues[currentTextId].isAnswerNeeded)
            {
                dialogueBox.SetActive(false);
                answerBox.SetActive(true);
                DisplayAnswer(dialogues[currentTextId].nextTextId);
            }

            else
            {
                if (dialogues[currentTextId].nextTextId == -1 ||
                    tutorialManager.isQuestAchieved && dialogues[currentTextId].nextTextId == -2)
                {
                    EndDialogue();
                }

                else
                {
                    DisplayNextSentence(dialogues[currentTextId].nextTextId);
                }
            }
        }
    }

    public void Answer1OnClick()
    {
        dialogueBox.SetActive(true);
        answerBox.SetActive(false);
        DisplayNextSentence(playerAnswers[currentAnswerId].nextTextId1);

        //QUEST ACTIVATION MAY LOCK && FIXING SHIT

        tutorialManager.ActivateQuest();
    }

    public void Answer2OnClick()
    {
        dialogueBox.SetActive(true);
        answerBox.SetActive(false);
        DisplayNextSentence(playerAnswers[currentAnswerId].nextTextId2);
    }

    public void Answer3OnClick()
    {
        dialogueBox.SetActive(true);
        answerBox.SetActive(false);
        DisplayNextSentence(playerAnswers[currentAnswerId].nextTextId3);
    }

    public void Answer4OnClick()
    {
        dialogueBox.SetActive(true);
        answerBox.SetActive(false);
        DisplayNextSentence(playerAnswers[currentAnswerId].nextTextId4);
    }

    private IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        
        foreach (char letter in sentence.ToCharArray())
        {
            if (isTextWritten)
            {
                dialogueText.text = sentence;
                yield break;
            }
            dialogueText.text += letter;
            yield return null;
        }
        isTextWritten = true;
    }
    #endregion
}