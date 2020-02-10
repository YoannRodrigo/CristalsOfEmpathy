using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Portal))]
[CanEditMultipleObjects]
public class PortalEditor : Editor
{
    void OnEnable()
    {}

    public override void OnInspectorGUI()
    {
        Portal portal = (Portal) target;
        DrawDefaultInspector();

        if(portal.levelDestination == "")
        {
            EditorGUILayout.HelpBox("Please enter the name of the level destination.", MessageType.Warning);
        }

        if(portal.portalDestination == -1)
        {
            EditorGUILayout.HelpBox("Please enter the id of the portal id of the level destination.", MessageType.Warning);
        }

        if(portal.portalDestination < -1 ) portal.portalDestination = -1;


        if(Vector3.Distance(portal.spawn, portal.transform.position) < portal.range) 
        {
            EditorGUILayout.HelpBox("SPAWN POINT IS INSIDE THE PORTAL", MessageType.Error);
        }
    }

    public void OnSceneGUI()
    {
        Portal portal = (Portal) target;

        portal.spawn = Handles.PositionHandle(portal.spawn, Quaternion.identity);

		Handles.color = new Color32(0, 0, 0, 255);
        GUI.skin.label.normal.textColor = new Color32(0, 0, 0, 255);
        Handles.Label(portal.spawn, "Apparition Point");
        Handles.DrawLine(portal.spawn, portal.transform.position);
    }
}
