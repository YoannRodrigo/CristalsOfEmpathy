using UnityEngine;

public class GuardianLaunchDialogue : MonoBehaviour
{
    public InteractibleLoveGardien loveGardien;
    public InteractibleFearGardien fearGardien;
    public InteractibleAversionGardien aversionGardien;
    public InteractibleCuriosityGardien curiosityGardien;

    private void Start()
    {
        DialogueManager.instance.gameObject.SetActive(true);
        if (EndGameManager.instance.inFearBranch)
        {
            fearGardien.Speak();
        }

        if (EndGameManager.instance.inAversionBranch)
        {
            aversionGardien.Speak();
        }

        if (EndGameManager.instance.inLoveBranch)
        {
            loveGardien.Speak();
        }

        if (EndGameManager.instance.inCuriosityBranch)
        {
            curiosityGardien.Speak();
        }
    }
}
