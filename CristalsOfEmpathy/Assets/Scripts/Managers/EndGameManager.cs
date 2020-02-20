﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{
    public List<string> pnjNames = new List<string>();
    public GameObject guardianPrefab;

    public static EndGameManager instance;
    private BarPointsHandler.Emotions maxEmotion;
    private bool isGuardianAlreadySpawned;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (pnjNames.Count > 11 && !isGuardianAlreadySpawned)
        {
            isGuardianAlreadySpawned = true;
            CheckBar();
            switch (maxEmotion)
            {
                case BarPointsHandler.Emotions.LOVE:
                    Instantiate(guardianPrefab).GetComponent<InteractibleLoveGardien>().Speak();
                    break;
                case BarPointsHandler.Emotions.FEAR:
                    Instantiate(guardianPrefab).GetComponent<InteractibleFearGardien>().Speak();
                    break;
                case BarPointsHandler.Emotions.CURIOSITY:
                    Instantiate(guardianPrefab).GetComponent<InteractibleCuriosityGardien>().Speak();
                    break;
                case BarPointsHandler.Emotions.AVERSION:
                    Instantiate(guardianPrefab).GetComponent<InteractibleAversionGardien>().Speak();
                    break;
                case BarPointsHandler.Emotions.NONE:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    private void CheckBar()
    {
        maxEmotion = BarPointsHandler.GetMaxBar();
    }
    
    
}
