#region Using Directives

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

#endregion

public class DialogueManager : MonoBehaviour
{
    #region Member Variables
    public static DialogueManager instance;
    public void Awake()
    {
        if(instance == null)
        {
            transform.parent = null;
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    [Header("References")]
    public Image portrait;
    public TextMeshProUGUI pnjNameText;
    public TextMeshProUGUI dialogueText;
    public int lastId;
    [Header("Holders")]
    public GameObject dialogueholder;
    public GameObject sentencesHolder;
    public GameObject answersHolder;

    // Une action C# qui peut contenir plusieurs petit bout de "code" et être executé quand tu veux
    public System.Action onDialogueEnd;
    private GameObject answerPrefab;
    List<AnswerButton> answerButtons = new List<AnswerButton>();
    private ScriptablePNJ dialogue;
    private int currentTextId;
    private int currentAnswerId;
    private bool isTextWritten;
    
    private bool answersNeedToBeOverrided;
    private int newPlayersAnswersId;
    private int newAnswersId;
    private int oldAnswerId;


    public void Start()
    {
        answerPrefab = answersHolder.transform.GetChild(0).gameObject;
        answerPrefab.SetActive(false);
    }

    public bool Initialize(ScriptablePNJ dialogue, int start = 0, System.Action onEnd = null)
    {
        if(this.dialogue != null )
        {
            Debug.Log("Dialogue is already playing.");
            return false;
        }
        else Debug.Log("Initializing " + dialogue);

        InterfaceManager.instance.GameUI(false);
        dialogueholder.SetActive(true);
        this.dialogue = dialogue;
        DisplayNextSentence(start);
        // Tu peux en faire un argument et plug n'importe quel fonction dedans, le += ajoute ton bout de code au reste de l'event
        if(onEnd != null) onDialogueEnd += onEnd;

        return true;
    }

    private void EndDialogue()
    {
        InterfaceManager.instance.GameUI(true);
        dialogueholder.SetActive(false);
        dialogue = null;
        // L'event se lance et on le réinitialise :)
        if(onDialogueEnd != null)
        {
            onDialogueEnd.Invoke();
            onDialogueEnd = null;
        }
    }

    public void DisplayNextSentence(int id)
    {
        if (id == -1) 
        {
           EndDialogue();
           return;
        }
        
        lastId = id;

        sentencesHolder.SetActive(true);
        currentTextId = id;
        if(dialogue.dialogues[id].profilePnj == null)
        {
            pnjNameText.text = "Speaker Unknown";
            Debug.Log("No dialogue found in sentence with id : " + id + ", in the " + dialogue + " dialogue.");
        }
        else
        {
            pnjNameText.text = dialogue.dialogues[id].profilePnj.pnjName;    
        }
        
        portrait.sprite = dialogue.dialogues[id].GetSpriteWithEmotion();
        portrait.enabled = portrait.sprite != null;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(dialogue.dialogues[id].sentence));
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
        foreach (PlayerAnswer pa in dialogue.playerAnswers[id].playerAnswers.Where(pa => count < 4))
        {
            if (answersNeedToBeOverrided && currentAnswerId == newPlayersAnswersId && count == oldAnswerId)
            {
                CreateAnswerButton(dialogue.playerAnswers[id].playerAnswers[newAnswersId].text, newAnswersId);
                answersNeedToBeOverrided = false;
            }
            else
            {
                CreateAnswerButton(pa.text, count);
            }

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
            if (dialogue.dialogues[currentTextId].isAnswerNeeded)
            {
                sentencesHolder.SetActive(false);
                answersHolder.SetActive(true);
                DisplayAnswers(dialogue.dialogues[currentTextId].nextTextId);
            }

            else
            {
                if (dialogue.dialogues[currentTextId].nextTextId == -1 || TutorialManager.instance && TutorialManager.instance.isQuestAchieved && dialogue.dialogues[currentTextId].nextTextId == -2)
                    EndDialogue();

                else
                    DisplayNextSentence(dialogue.dialogues[currentTextId].nextTextId);
            }
        }
    }
    
    public void OverrideAnswers(int playerAnswersId, int oldAnswerId, int newAnswerId)
    {
        answersNeedToBeOverrided = true;
        newPlayersAnswersId = playerAnswersId;
        newAnswersId = newAnswerId;
        this.oldAnswerId = oldAnswerId;
    }

    public void Answer(int id)
    {
        sentencesHolder.SetActive(true);
        answersHolder.SetActive(false);
        UpdateDisplay(id);
    }

    private void UpdateDisplay(int answerId)
    {
        PlayerAnswers playerAnswer = dialogue.playerAnswers[currentAnswerId];

        DisplayNextSentence(dialogue.playerAnswers[currentAnswerId].GetNextId(answerId));

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