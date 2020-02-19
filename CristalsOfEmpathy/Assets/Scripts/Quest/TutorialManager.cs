using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager instance;
    private void Awake() {instance = this;}
    
    [Header("Read-only")]
    public bool isQuestActivated;
    public bool isQuestAchieved;
    public bool isQuestSubmitted;
    [Header("Reference")]
    public NonPlayableCharacter helise;
    public Portal portalToFlorist;
    public ScriptablePNJ dialogueWhenAchieved;
    public List<GameObject> berlingotsList = new List<GameObject>();
    [Header("Markers")]
    public Transform heliseRunPointAfterDialogue;
    public Transform heliseSpawnerWhenAchieved;

    [ContextMenu("OnBerlingotEaten()")]
    public void OnBerlingotEaten()
    {
        if(Check())
        {
            isQuestAchieved = true;
            portalToFlorist.activated = true;

            PlayerMovement p = LevelManager.instance.player;
            p.UnFreeze();

            helise.gameObject.SetActive(true);
            helise.transform.position = heliseSpawnerWhenAchieved.position;
            helise.movement.SetSpeed(5f);
            helise.movement.GoThere(p.transform.position + p.transform.forward * 3f, true);
            helise.movement.onDestinationReached += () =>
            {
                DialogueManager.instance.Initialize(dialogueWhenAchieved, 0, () => 
                {
                    p.UnFreeze();
                    helise.movement.GoThere(portalToFlorist.transform.position, true);
                    helise.movement.onDestinationReached += () =>
                    {
                        helise.gameObject.SetActive(false);
                    };
                });
            };
        }
    }

    public bool Check()
    {
        berlingotsList.RemoveAll(item => item == null);
        if (berlingotsList.Count == 0) return true;
        else return false;
    }

    public void ActivateQuest()
    {
        isQuestActivated = true;
    }
}