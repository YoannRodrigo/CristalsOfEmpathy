using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "ScriptableObjects/ScriptablePNJ", order = 1)]
public class ScriptablePNJ : ScriptableObject
{
    public Dialogue[] dialogues;
    public PlayerAnswers[] playerAnswers;
}
