using UnityEngine;


public class GhostController : MonoBehaviour
{
    private Transform playerTransform;
    private bool isEnlight;
    private float timeToReachPlayer;
    private float timeBeforeDeath;
    private float timeInEnlightment;
    private float speed;
    private GameObject playerLight;
    
    public void SetPlayerTransform(Transform playerTransform)
    {
        this.playerTransform = playerTransform;
    }

    public void SetDifficulty(float timeBeforeDeath, float timeToReachPlayer)
    {
        this.timeBeforeDeath = timeBeforeDeath;
        this.timeToReachPlayer = timeToReachPlayer;
    }

    private float SetSpeed()
    {
        return Vector3.Distance(transform.position, playerTransform.position) / timeToReachPlayer;
    }

    private void Start()
    {
        speed = SetSpeed();
    }

    private void Update()
    {
        if (playerLight != null && !playerLight.GetComponent<Light>().enabled)
        {
            isEnlight = false;
        }
        if (isEnlight)
        {
            timeInEnlightment += Time.deltaTime;
            if (timeInEnlightment >= timeBeforeDeath)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            Vector3 targetDirection = (playerTransform.position - transform.position).normalized;
            transform.Translate(speed * Time.deltaTime * targetDirection);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Light"))
        {
            playerLight = other.gameObject;
            isEnlight = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Light"))
        {
            isEnlight = false;
        }
    }
}
