using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MayorHitDetection : MonoBehaviour
{
    public List<GameObject> tomatoSplash = new List<GameObject>();
    public Animator animator;
    public AversionEnigmaMenuManager gameManager;
    private List<GameObject> tomatoesOnMayor = new List<GameObject>();
    private float timeSinceLastTomatoClean;
    private const float TIME_FOR_CLEAN_A_TOMATO = 1;
    private static readonly int getHit = Animator.StringToHash("GetHit");

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Tomato"))
        {
            if (other.transform.localScale.x < 0.5)
            {
                int randomIndex = Random.Range(0, tomatoSplash.Count);
                tomatoesOnMayor.Add(Instantiate(tomatoSplash[randomIndex], other.transform.position, other.transform.rotation, transform));
                Destroy(other.gameObject);
                animator.SetTrigger(getHit);
            }
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
                
            }
        }
    }
}
