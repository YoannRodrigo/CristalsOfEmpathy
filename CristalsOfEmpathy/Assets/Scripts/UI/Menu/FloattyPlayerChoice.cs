using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FloattyPlayerChoice : MonoBehaviour
{

    private const float MAX_OFFSET_Y = 100f;
    private const float SPEED = 0.05f;
    private float currentOffsetGoal;
    private float timeSinceOffsetReached;

    private void Start()
    {
        currentOffsetGoal = Random.Range(0,2) == 0 ? -MAX_OFFSET_Y : MAX_OFFSET_Y;
    }

    private void Update()
    {
        timeSinceOffsetReached += Time.deltaTime;
        Vector3 localPosition = transform.localPosition;
        localPosition = Vector3.Lerp(localPosition, new Vector3(localPosition.x, currentOffsetGoal,0), SPEED*timeSinceOffsetReached);
        transform.localPosition = localPosition;
        if (Math.Abs(transform.localPosition.y - currentOffsetGoal) < 5f)
        {
            currentOffsetGoal = -currentOffsetGoal;
            timeSinceOffsetReached = 0;
        }
    }
}
