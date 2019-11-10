

using UnityEngine;


public class ForceDialogue : MonoBehaviour
{
    public InteractiblePnj interactiblePnj;

    private void OnTriggerEnter(Collider other)
    {
        interactiblePnj.StartDialogue();
    }
}
