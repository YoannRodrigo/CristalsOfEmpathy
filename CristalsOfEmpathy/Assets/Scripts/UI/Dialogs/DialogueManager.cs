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
    public static DialogueManager instance;
    void Awake() {instance = this;}

    public TutorialManager tutorialManager;
    [Header("References")]
    public Image portrait;
    public TextMeshProUGUI pnjNameText;
    public TextMeshProUGUI dialogueText;
    [Header("Holders")]
    public GameObject dialogueholder;
    public GameObject sentencesHolder;
    public GameObject answersHolder;

    // Une action C# qui peut contenir plusieurs petit bout de "code" et être executé quand tu veux
    public System.Action onDialogueEnd;
    private GameObject answerPrefab;
    List<AnswerButton> answerButtons = new List<AnswerButton>();
    private ScriptablePNJ speaker;
    private int currentTextId;
    private int currentAnswerId;
    private bool isTextWritten;

    public void Start()
    {
        answerPrefab = answersHolder.transform.GetChild(0).gameObject;
        answerPrefab.SetActive(false);
    }

    public void Initialize(ScriptablePNJ dialogue, int start = 0, System.Action onEnd = null)
    {
        Debug.Log("Initializing " + dialogue);

        InterfaceManager.instance.GameUI(false);
        dialogueholder.SetActive(true);
        speaker = dialogue;
        DisplayNextSentence(start);
        // Tu peux en faire un argument et plug n'importe quel fonction dedans, le += ajoute ton bout de code au reste de l'event
        if(onEnd != null) onDialogueEnd += onEnd;
    }

    private void EndDialogue()
    {
        InterfaceManager.instance.GameUI(true);
        dialogueholder.SetActive(false);

        // L'event se lance et on le réinitialise :)
        if(onDialogueEnd != null)
        {
            onDialogueEnd.Invoke();
            onDialogueEnd = null;
        }
    }

    public void DisplayNextSentence(int id)
    {
        if (id == -1) EndDialogue();

        sentencesHolder.SetActive(true);
        currentTextId = id;
        pnjNameText.text = speaker.dialogues[id].profilePnj.pnjName;
        portrait.sprite = speaker.dialogues[id].GetSpriteWithEmotion();
        portrait.enabled = portrait.sprite != null;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(speaker.dialogues[id].sentence));
    }

    public void DestroyAnswers()
    {
        foreach(AnswerButton b in answerButtons) Destroy(b.gameObject);
        answerButtons.Clear();
    }

    public void DisplayAnswers(int id)
    {
        DestroyAnswers();
        sentencesHolder.SetActive(false);
        answersHolder.SetActive(true);
        currentAnswerId = id;
        int count = 0;
        foreach(PlayerAnswer pa in speaker.playerAnswers[id].playerAnswers)
        {
            CreateAnswerButton(pa.text, count);
            count++;
        }
    }

    public void CreateAnswerButton(string text, int id)
    {
        AnswerButton answer = Instantiate(answerPrefab, answersHolder.transform).GetComponent<AnswerButton>();
        answer.gameObject.SetActive(true);
        answer.text.text = text;
        answer.button.onClick.RemoveAllListeners();
        answer.button.onClick.AddListener(() => {this.Answer(id);});
        answerButtons.Add(answer);
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
            if (speaker.dialogues[currentTextId].isAnswerNeeded)
            {
                sentencesHolder.SetActive(false);
                answersHolder.SetActive(true);
                DisplayAnswers(speaker.dialogues[currentTextId].nextTextId);
            }

            else
            {
                if (speaker.dialogues[currentTextId].nextTextId == -1 || tutorialManager && tutorialManager.isQuestAchieved && speaker.dialogues[currentTextId].nextTextId == -2)
                    EndDialogue();

                else
                    DisplayNextSentence(speaker.dialogues[currentTextId].nextTextId);
            }
        }
    }

    public void Answer(int id)
    {
        sentencesHolder.SetActive(true);
        answersHolder.SetActive(false);
        UpdateDisplay(id);

        //QUEST ACTIVATION MAY LOCK && FIXING SHIT
        if(id == 0 && tutorialManager)
            tutorialManager.ActivateQuest();
    }

    private void UpdateDisplay(int answerId)
    {
        PlayerAnswers playerAnswer = speaker.playerAnswers[currentAnswerId];

        DisplayNextSentence(speaker.playerAnswers[currentAnswerId].GetNextId(answerId));

        BarPointsHandler.UpdateEmotionPoints(playerAnswer.GetEmotion(answerId), playerAnswer.GetEmotionInfluence(answerId));
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