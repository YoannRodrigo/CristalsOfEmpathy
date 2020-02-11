using System;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{
    public GameObject helisePrefab;
    public ScriptablePNJ loveEnigmaText;
    public ScriptablePNJ fearEnigmaText;
    public ScriptablePNJ aversionEnigmaText;
    public ScriptablePNJ curiosityEnigmaText;

    public static EndGameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SpawnHelise(BarPointsHandler.Emotions emotion)
    {
        Transform playerTransform = FindObjectOfType<PlayerMovement>().transform;
        GameObject helise = Instantiate(helisePrefab, playerTransform.position + 0.8f * playerTransform.forward,
            playerTransform.rotation);
        switch (emotion)
        {
            case BarPointsHandler.Emotions.LOVE:
                helise.GetComponent<InteractibleEndGameHelise>().scriptablePnj = loveEnigmaText;
                break;
            case BarPointsHandler.Emotions.FEAR:
                helise.GetComponent<InteractibleEndGameHelise>().scriptablePnj = fearEnigmaText;
                break;
            case BarPointsHandler.Emotions.CURIOSITY:
                helise.GetComponent<InteractibleEndGameHelise>().scriptablePnj = curiosityEnigmaText;
                break;
            case BarPointsHandler.Emotions.AVERSION:
                helise.GetComponent<InteractibleEndGameHelise>().scriptablePnj = aversionEnigmaText;
                break;
            case BarPointsHandler.Emotions.NONE:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(emotion), emotion, null);
        }
        helise.GetComponent<InteractibleEndGameHelise>().SetEmotion(emotion);
    }
}
