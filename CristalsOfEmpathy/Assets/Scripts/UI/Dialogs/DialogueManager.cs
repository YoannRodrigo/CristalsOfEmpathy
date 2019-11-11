#region Using Directives
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

#endregion

public class DialogueManager : MonoBehaviour
{
    #region Member Variables

    public Text pnjNameText;
    public Text dialogueText;
    public Text answer1;
    public Text answer2;
    public Text answer3;
    public Text answer4;
    public Text answer5;
    public Text answer6;

    public GameObject dialogueBox;
    public GameObject answerBox;
    public GameObject joystick;
    public GameObject pauseButton;
    public GameObject inventoryButton;

    public bool isQuestActivated = false;
    public bool isQuestAchieved = false;

    private int currentTextId;
    private int currentAnswerId;
    private readonly List<Dialogue> dialogues = new List<Dialogue>();
    private readonly List<PlayerAnswers> playerAnswers = new List<PlayerAnswers>();
    #endregion

    #region Methods

    public void StartDialogue(Dialogue[] dialogues, int startId = 0)
    {
        // QUEST LOCKING DIALOG
        if (!isQuestActivated)
        {
            joystick.SetActive(false);
            pauseButton.SetActive(false);
            inventoryButton.SetActive(false);
            this.dialogues.Clear();
            foreach (Dialogue dialogue in dialogues)
            {
                this.dialogues.Add(dialogue);
            }
            DisplayNextSentence(startId);
        }

        else
        {
            joystick.SetActive(false);
            pauseButton.SetActive(false);
            inventoryButton.SetActive(false);
            this.dialogues.Clear();
            foreach (Dialogue dialogue in dialogues)
            {
                this.dialogues.Add(dialogue);
            }
        }

        // SAMPLE DIALOG WHEN QUEST ACHIEVED
        if (isQuestAchieved)
        {
            joystick.SetActive(false);
            pauseButton.SetActive(false);
            inventoryButton.SetActive(false);
            this.dialogues.Clear();
            foreach (Dialogue dialogue in dialogues)
            {
                this.dialogues.Add(dialogue);
            }
            DisplayNextSentence(8);
        }
    }

    public void StartDialogue(Dialogue[] dialogues, PlayerAnswers[] playerAnswers, int startId = 0)
    {
        this.playerAnswers.Clear();
        foreach (PlayerAnswers playerAnswer in playerAnswers)
        {
            this.playerAnswers.Add(playerAnswer);
        }
        StartDialogue(dialogues, startId);
    }

    private void EndDialogue()
    {
        dialogueBox.SetActive(false);
        joystick.SetActive(true);
        pauseButton.SetActive(true);
        inventoryButton.SetActive(true);
    }

    private void DisplayNextSentence(int id)
    {
        currentTextId = id;
        pnjNameText.text = dialogues[id].pnjName;

        StopAllCoroutines();
        StartCoroutine(TypeSentence(dialogues[id].sentence));
    }

    private void DisplayAnswer(int id)
    {
        currentAnswerId = id;
        answer1.text = playerAnswers[id].text1;
        answer2.text = playerAnswers[id].text2;
        answer3.text = playerAnswers[id].text3;
        answer4.text = playerAnswers[id].text4;
    }

    public void NextSentenceOnClick()
    {
        // WE CAN NOW TP IF QUEST ACHIEVED
        if (isQuestAchieved && dialogues[currentTextId].nextTextId == -2)
        {
            EndDialogue();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (dialogues[currentTextId].isAnswerNeeded)
        {
            dialogueBox.SetActive(false);
            answerBox.SetActive(true);
            DisplayAnswer(dialogues[currentTextId].nextTextId);
        }

        else
        {
            if (dialogues[currentTextId].nextTextId == -1)
            {
                EndDialogue();
            }
            else
            {
                DisplayNextSentence(dialogues[currentTextId].nextTextId);
            }
        }
    }

    public void Answer1OnClick()
    {
        dialogueBox.SetActive(true);
        answerBox.SetActive(false);
        DisplayNextSentence(playerAnswers[currentAnswerId].nextTextId1);

        //QUEST ACTIVATION MAY LOCK

        isQuestActivated = true;
        Debug.Log("Quest activated");
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
            dialogueText.text += letter;
            yield return null;
        }
    }
    #endregion
}