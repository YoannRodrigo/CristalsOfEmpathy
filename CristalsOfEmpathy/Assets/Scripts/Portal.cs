﻿using UnityEngine;
#if UNITY_EDITOR
    using UnityEditor;
#endif

[RequireComponent(typeof(SphereCollider))]
public class Portal : MonoBehaviour
{
    private SphereCollider sphere;
    [Header("Settings")]
    public Vector3 spawn;

    public bool activated = true;
    public float range = 2f;

    public string levelDestination;
    public int portalDestination;

    public void Awake()
    {
        sphere = GetComponent<SphereCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(activated && other.GetComponent<PlayerMovement>() != null)
        {
            GeneralGameManager.instance.Go(levelDestination, portalDestination);
        }
    }

    public Vector3 GetDirection()
    {
        return (spawn - transform.position).normalized;
    }

#if UNITY_EDITOR
    public void OnValidate()
    {
        sphere = GetComponent<SphereCollider>();
        sphere.radius = range;
        sphere.isTrigger = true;
        sphere.enabled = activated;
    }

    public void OnDrawGizmos()
    {
        Color c = new Color32(0, 0, 0, 255);

        if(activated)
        {
            if(Vector3.Distance(spawn, transform.position) < range) Handles.color = new Color32(255, 0, 0, 100);
            else Handles.color = new Color32(0, 255, 0, 100);
            Handles.DrawSolidArc(transform.position, Vector3.up, Vector3.right, 360f, range);

            Handles.color = c;
            GUI.skin.label.normal.textColor = c;
            Handles.DrawWireDisc(transform.position, Vector3.up, range);
            Handles.Label(transform.position, "TO " + levelDestination);
        }
        else Handles.Label(transform.position, "Inactive Portal");
        
        Handles.DrawWireDisc(spawn, Vector3.up, 0.5f);
        Handles.DrawLine(spawn, transform.position);
        Handles.Label(spawn, "Spawn");
    }
#endif
}
