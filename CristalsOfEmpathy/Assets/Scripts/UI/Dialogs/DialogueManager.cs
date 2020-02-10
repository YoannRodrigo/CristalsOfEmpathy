#region Using Directives

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

#endregion

public class DialogueManager : MonoBehaviour
{
    #region Member Variables

    public TutorialManager tutorialManager;

    public TextMeshProUGUI pnjNameText;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI answer1;
    public TextMeshProUGUI answer2;
    public TextMeshProUGUI answer3;
    public TextMeshProUGUI answer4;

    public GameObject dialogueBox;
    public GameObject answerBox;
    public GameObject joystick;
    public GameObject pauseButton;
    public GameObject inventoryButton;

    private InteractiblePnj interactiblePnj;
    private int currentTextId;
    private int currentAnswerId;
    private bool isTextWritten;
    private bool isDialogueEnded = true;
    public List<Dialogue> dialogues = new List<Dialogue>();
    public List<PlayerAnswers> playerAnswers = new List<PlayerAnswers>();

    #endregion

    #region Methods

    public void SetInteractiblePnj(InteractiblePnj interactiblePnj)
    {
        this.interactiblePnj = interactiblePnj;
    }

    public bool IsDialogueEnded()
    {
        return isDialogueEnded;
    }

    public void StartDialogue(Dialogue[] dialogues, int startId = 0)
    {
        // QUEST LOCKING DIALOG & FIXING SHIT
        isDialogueEnded = false;
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
        foreach (PlayerAnswers playerAnswer in playerAnswers) this.playerAnswers.Add(playerAnswer);
        StartDialogue(dialogues, startId);
    }

    public void OnDialogueInteraction(Dialogue[] dialogues)
    {
        joystick.SetActive(false);
        pauseButton.SetActive(false);
        inventoryButton.SetActive(false);
        foreach (Dialogue dialogue in dialogues) this.dialogues.Add(dialogue);
    }

    private void EndDialogue()
    {
        interactiblePnj.OnDialogEnded();
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
        isDialogueEnded = true;
        interactiblePnj = null;
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
        answer1.text = playerAnswers[id].GetText(0);
        answer2.text = playerAnswers[id].GetText(1);
        answer3.text = playerAnswers[id].GetText(2);
        answer4.text = playerAnswers[id].GetText(3);
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
                if (dialogues[currentTextId].nextTextId == -1 || tutorialManager && tutorialManager.isQuestAchieved && dialogues[currentTextId].nextTextId == -2)
                    EndDialogue();

                else
                    DisplayNextSentence(dialogues[currentTextId].nextTextId);
            }
        }
    }

    public void Answer1OnClick()
    {
        dialogueBox.SetActive(true);
        answerBox.SetActive(false);
        UpdateDisplay(0);
        //QUEST ACTIVATION MAY LOCK && FIXING SHIT

        if(tutorialManager)
            tutorialManager.ActivateQuest();
    }

    public void Answer2OnClick()
    {
        dialogueBox.SetActive(true);
        answerBox.SetActive(false);
        UpdateDisplay(1);
    }

    public void Answer3OnClick()
    {
        dialogueBox.SetActive(true);
        answerBox.SetActive(false);
        UpdateDisplay(2);
    }

    public void Answer4OnClick()
    {
        dialogueBox.SetActive(true);
        answerBox.SetActive(false);
        UpdateDisplay(3);
    }

    private void UpdateDisplay(int answerId)
    {
        PlayerAnswers playerAnswer = playerAnswers[currentAnswerId];
        DisplayNextSentence(playerAnswer.GetNextId(answerId));
        BarPointsHandler.UpdateEmotionPoints(playerAnswer.GetEmotion(answerId),
            playerAnswer.GetEmotionInfluence(answerId));
    }

    private IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";

        foreach (char letter in sentence)
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