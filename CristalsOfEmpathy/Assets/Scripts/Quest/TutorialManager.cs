#region Using Directives

using System.Collections.Generic;
using UnityEngine;

#endregion

public class TutorialManager : MonoBehaviour
{
    //HANDLING TUTORIAL QUEST && BERLINGOTS COUNT

    #region Member Variables

    public bool isQuestActivated;
    public bool isQuestAchieved;
    public bool isQuestSubmitted;
    public FlyablePnj heliseFly;
    public List<GameObject> berlingotsList = new List<GameObject>();
    public GameObject dialogueLauncher;

    #endregion

    #region Methods

    private void Start()
    {
        heliseFly.AllowPnjToFly(false);
    }

    private void Update()
    {
        berlingotsList.RemoveAll(item => item == null);
        if (berlingotsList.Count == 0)
        {
            heliseFly.AllowPnjToFly();
            isQuestAchieved = true;
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