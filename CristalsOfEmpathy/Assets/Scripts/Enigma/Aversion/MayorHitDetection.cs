using System.Collections.Generic;
using UnityEngine;

public class MayorHitDetection : MonoBehaviour
{
    public List<GameObject> tomatoSplash = new List<GameObject>();
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Tomato"))
        {
            if (other.transform.localScale.x < 0.5)
            {
                int randomIndex = Random.Range(0, tomatoSplash.Count);
                Instantiate(tomatoSplash[randomIndex], other.transform.position, other.transform.rotation, transform);
                Destroy(other.gameObject);
            }
        }
    }
}
