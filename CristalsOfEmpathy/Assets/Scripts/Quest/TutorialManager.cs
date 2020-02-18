#region Using Directives

using System.Collections.Generic;
using UnityEngine;

#endregion

public class TutorialManager : MonoBehaviour
{
    //HANDLING TUTORIAL QUEST && BERLINGOTS COUNT

    #region Member Variables
    public static TutorialManager instance;
    private void Awake() {instance = this;}
    
    public bool isQuestActivated;
    public bool isQuestAchieved;
    public bool isQuestSubmitted;
    public HeliseIaTutoMovement heliseMovement;
    public List<GameObject> berlingotsList = new List<GameObject>();
    public GameObject dialogueLauncher;
    public Portal portalToFlorist;
    #endregion

    #region Methods


    private void Update()
    {
        berlingotsList.RemoveAll(item => item == null);
        if (berlingotsList.Count == 0)
        {
            heliseMovement.AllowHeliseToMove();
            isQuestAchieved = true;
            portalToFlorist.activated = true;
            if (dialogueLauncher) dialogueLauncher.SetActive(true);
        }
    }

    public void ActivateQuest()
    {
        isQuestActivated = true;
        foreach (GameObject berlingot in berlingotsList)
            berlingot.GetComponent<InteractibleBerlingot>().ActivateQuest();
    }

    #endregion
}