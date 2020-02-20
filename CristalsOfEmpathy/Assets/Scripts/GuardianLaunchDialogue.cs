using UnityEngine;

public class GuardianLaunchDialogue : MonoBehaviour
{
    public InteractibleLoveGardien loveGardien;
    public InteractibleFearGardien fearGardien;
    public InteractibleAversionGardien aversionGardien;
    public InteractibleCuriosityGardien curiosityGardien;

    private void Start()
    {
        if (EndGameManager.instance.inFearBranch)
        {
            fearGardien.Speak();
        }
    }
}
