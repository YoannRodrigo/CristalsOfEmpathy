using UnityEngine;

public class PlayerHitDetector : MonoBehaviour
{
    public FearEnigmaManager fearEnigmaManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Light"))
            fearEnigmaManager.SetPlayerEnlight(true);
        else if (other.CompareTag("Ghost")) print("Dead");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Light")) fearEnigmaManager.SetPlayerEnlight(false);
    }
}