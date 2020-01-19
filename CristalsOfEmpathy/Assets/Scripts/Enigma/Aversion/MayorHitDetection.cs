using System.Collections.Generic;
using UnityEngine;

public class MayorHitDetection : MonoBehaviour
{
    private const float TIME_FOR_CLEAN_A_TOMATO = 1;
    private static readonly int getHit = Animator.StringToHash("GetHit");
    public Animator animator;
    public AversionEnigmaMenuManager gameManager;
    private float timeSinceLastTomatoClean;
    private readonly List<GameObject> tomatoesOnMayor = new List<GameObject>();
    public List<GameObject> tomatoSplash = new List<GameObject>();

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Tomato"))
            if (other.transform.localScale.x < 0.5)
            {
                int randomIndex = Random.Range(0, tomatoSplash.Count);
                tomatoesOnMayor.Add(Instantiate(tomatoSplash[randomIndex], other.transform.position,
                    other.transform.rotation, transform));
                Destroy(other.gameObject);
                animator.SetTrigger(getHit);
                gameManager.UpdateScore(100);
            }
    }

    private void Update()
    {
        if (gameManager.GetGameState() == AversionEnigmaMenuManager.GameState.WATER && Input.touchCount > 0)
        {
            timeSinceLastTomatoClean += Time.deltaTime;
            if (timeSinceLastTomatoClean > TIME_FOR_CLEAN_A_TOMATO && tomatoesOnMayor.Count > 0)
            {
                timeSinceLastTomatoClean = 0;
                int randomIndex = Random.Range(0, tomatoesOnMayor.Count);
                GameObject tomatoToRemove = tomatoesOnMayor[randomIndex];
                tomatoesOnMayor.Remove(tomatoesOnMayor[randomIndex]);
                Destroy(tomatoToRemove);
                gameManager.UpdateScore(-100);
            }
        }
        else
        {
            timeSinceLastTomatoClean = 0;
        }
    }
}