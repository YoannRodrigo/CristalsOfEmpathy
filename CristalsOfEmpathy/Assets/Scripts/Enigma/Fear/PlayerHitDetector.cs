#region

using UnityEngine;

#endregion

public class PlayerHitDetector : MonoBehaviour
{
    public FearEnigmaManager fearEnigmaManager;
    private GameObject playerLight;
    private void Update()
    {
        if (playerLight != null && !playerLight.GetComponent<Light>().enabled)
        {
            fearEnigmaManager.SetPlayerEnlight(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Light"))
        {
            playerLight = other.gameObject;
            fearEnigmaManager.SetPlayerEnlight(true);
        }
        else if (other.CompareTag("Ghost"))
        {
            print("Dead");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Light"))
        {
            fearEnigmaManager.SetPlayerEnlight(false);
        }
    }
}