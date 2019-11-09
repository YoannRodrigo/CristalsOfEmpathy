
using UnityEngine;

[RequireComponent(typeof(InteractiblePnj))]
public class ForceDialogue : MonoBehaviour
{
    private InteractiblePnj interactiblePnj;
    private void Awake()
    {
        interactiblePnj = GetComponent<InteractiblePnj>();
    }

    private void Start()
    {
        interactiblePnj.StartDialogue();
    }
}
