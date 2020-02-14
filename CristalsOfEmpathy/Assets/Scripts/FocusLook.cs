﻿using UnityEngine;

public class FocusLook : MonoBehaviour
{
	public Transform head;
	public Vector3 adjustment;
	public float angleMax = 60f;
	public float speed = 10f;
	private bool targetOut = false;
	public bool isTargetOut { get { return targetOut; } }

    [HideInInspector] public bool isFocused;
    Transform transformTarget;
    Vector3 positionTarget;

    Vector3 targetDirection;
    Vector3 currentDirection;

    void Awake()
    {
        if(head == null) Destroy(this);
    }

    void LateUpdate()
    {
        if(!isFocused) return;

        targetDirection = transform.forward;

        if(transformTarget != null) 
            targetDirection = (transformTarget.position - head.position).normalized;
        else if(positionTarget != Vector3.zero) 
            targetDirection = (positionTarget - head.position).normalized;

		if (Vector3.Angle(targetDirection, transform.forward) > angleMax)
		{
			targetOut = true;
			targetDirection = transform.forward;
		}
		else targetOut = false;

        Look();
    }

    // FOCUS ON
    public void FocusOn(Vector3 position)
    {
        LooseFocus();
        Look();
        positionTarget = position;
        isFocused = true;
    }

    public void Look()
    {
        currentDirection = Vector3.Lerp(currentDirection, targetDirection, Time.deltaTime * speed);
        head.forward = currentDirection;
        head.Rotate(adjustment);
    }

    public void FocusOn(Transform transform)
    {
        LooseFocus();
        transformTarget = transform;
        isFocused = true;
    }

    // LOOSE FOCUS
    public void LooseFocus()
    {
        targetDirection = transform.forward;
        positionTarget = Vector3.zero;
        transformTarget = null;
        isFocused = false;
    }
}