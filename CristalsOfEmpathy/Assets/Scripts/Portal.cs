using UnityEngine;
#if UNITY_EDITOR
    using UnityEditor;
#endif

public class Portal : MonoBehaviour
{
    private SphereCollider sphere;
    [Header("Settings")]
    public float range;
    public Vector3 spawn;

    public string levelDestination;
    public int portalDestination;

    public void Awake()
    {
        sphere = GetComponent<SphereCollider>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerMovement>() != null)
        {
            // SWITCH SCENE AND SPAWN AT SPAWNER ID
        }
    }

#if UNITY_EDITOR
    public void OnValidate()
    {
        sphere = GetComponent<SphereCollider>();
        sphere.radius = range;
    }

    public void OnDrawGizmos()
    {

        if(Vector3.Distance(spawn, transform.position) < range) Handles.color = new Color32(255, 0, 0, 100);
        else Handles.color = new Color32(0, 255, 0, 100);
        Handles.DrawSolidArc(transform.position, Vector3.up, Vector3.right, 360f, range);

        Color c = new Color32(0, 0, 0, 255);
        Handles.color = c;
        GUI.skin.label.normal.textColor = c;
        Handles.Label(transform.position, "Portal to : " + levelDestination);
        Handles.DrawWireDisc(transform.position, Vector3.up, range);
    }
#endif
}
