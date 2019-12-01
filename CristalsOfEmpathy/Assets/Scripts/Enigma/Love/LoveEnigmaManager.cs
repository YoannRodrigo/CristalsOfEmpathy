#region Using Directives
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

#endregion
public class LoveEnigmaManager : MonoBehaviour
{
    #region Member Variables

    private const float TIME_BEFORE_OTHER_PERSONNAS = 1f;
    
    public List<Personna> personnas = new List<Personna>();
    public Image leftPortrait;
    public Image rightPortrait;
    public TextMeshProUGUI leftName;
    public TextMeshProUGUI rightName;
    public GameObject hearth;
    public GameObject windowsGame;
    public GameObject windowsConsigne;
    public GameObject windowsDialogue;
    public Animator canvasAnimator;
    
    private int currentLeftPersonna;
    private int currentRightPersonna;
    private bool isCoupleOk;
    private float timeSinceValidation;
    private static readonly int toDialogue = Animator.StringToHash("ToDialogue");
    private static readonly int toConsigne = Animator.StringToHash("ToConsigne");
    private static readonly int toGame = Animator.StringToHash("ToGame");

    #endregion

    #region Methods

    private void Start()
    {
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

    public void LeftArrowLeftOnClic()
    {
        currentLeftPersonna--;
        if (currentLeftPersonna < 0)
        {
            currentLeftPersonna = personnas.Count - 1;
        }
        if (currentLeftPersonna == currentRightPersonna)
        {
            currentLeftPersonna--;
            if (currentLeftPersonna < 0)
            {
                currentLeftPersonna = personnas.Count - 1;
            }
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
        if (currentRightPersonna < 0)
        {
            currentRightPersonna = personnas.Count - 1;
        }
        if (currentLeftPersonna == currentRightPersonna)
        {
            currentRightPersonna--;
            if (currentRightPersonna < 0)
            {
                currentRightPersonna = personnas.Count - 1;
            }
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
        if (personnas[currentLeftPersonna].couple == personnas[currentRightPersonna].couple)
        {
            hearth.SetActive(true);
            isCoupleOk = true;
        }
    }

    public void DialogueOnClic()
    {
        canvasAnimator.SetBool(toDialogue, true);
        canvasAnimator.SetBool(toGame, false);
    }

    public void ConsigneOnClic()
    {
        canvasAnimator.SetBool(toConsigne, true);
        canvasAnimator.SetBool(toGame, false);
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
                Personna leftPersonna = personnas[currentLeftPersonna];
                Personna rightPersonna = personnas[currentRightPersonna];
                personnas.Remove(leftPersonna);
                personnas.Remove(rightPersonna);
                if(personnas.Count != 0)
                {
                    ChooseRandomPersonna();
                }
            }
        }
    }

    #endregion
}
