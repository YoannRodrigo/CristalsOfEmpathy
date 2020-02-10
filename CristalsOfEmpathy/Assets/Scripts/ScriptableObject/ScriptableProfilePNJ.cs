using UnityEngine;

[CreateAssetMenu(fileName = "Profile", menuName = "ScriptableObjects/ScriptableProfilePNJ", order = 2)]
public class ScriptableProfilePNJ : ScriptableObject
{
    public string pnjName;
    public Sprite happyFace;
    public Sprite sadFace;
    public Sprite confuseFace;
    public Sprite angryFace;
    public Sprite fearFace;

}
