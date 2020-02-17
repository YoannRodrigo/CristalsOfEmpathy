using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
    using UnityEditor;
#endif

public class FlowerPath : MonoBehaviour
{

    [Header("References")]
    public List<GameObject> flowers = new List<GameObject>();
    public CollisionEventTransmitter collision;
    public ParticleSystem appearParticle;
    public ParticleSystem stepOnParticle;
    [Header("Settings")]
    public AnimationCurve scaleAnimationCurve;
    public float timeToGrow = 1f;
    public float scaleMultiplier = 1f;

    int current = -1;
    float timer = 0f;
    bool growing = false;

    void Start()
    {
        Initialise();
        current = 0;
        Appear(current);
    }

    void Initialise()
    {
        current = -1;
        timer = 0f;
        growing = false;

        foreach(GameObject f in flowers)
            f.SetActive(false);

        //collision.Clear();
        collision.onTriggerEnter += (other) => 
        {
            this.Next();
        };
    }

    void Update()
    {
        if(growing)
        {
            timer += Time.deltaTime;
            if(timer < timeToGrow)
            {
                flowers[current].transform.localScale = scaleAnimationCurve.Evaluate(timer/timeToGrow) * Vector3.one * scaleMultiplier;
            }
            else
            {
                timer = 0f;
                growing = false;
            }
        }
    }
    
    void Appear(int index)
    {
        if(index < 0 || index >= flowers.Count) return;
        flowers[index].SetActive(true);
        Destroy(Instantiate(appearParticle, flowers[index].transform.position, Quaternion.identity), 1f);
        growing = true;
    }

    void Next()
    {
        if(current >= 0 && current < flowers.Count)
        {
            //Destroy(Instantiate(stepOnParticle, flowers[current].transform), 1f);
        }

        current++;
        
        if(current >= 0 && current < flowers.Count)
        {
            Appear(current);
            collision.transform.position = flowers[current].transform.position;
        }
        else
        {
            collision.enabled = false;
        }
    }
    
    public GameObject GetLastElement()
    {
        return flowers[flowers.Count - 1];
    }

#if UNITY_EDITOR
    public void OnDrawGizmos()
    {  
        Handles.color = new Color32(255, 255, 255, 255);

        for(int i = 0; i < flowers.Count; i++)
        {
            Handles.Label(flowers[i].transform.position, "#" + i);

            if(i == 0)
            {
                Handles.DrawLine(transform.position, flowers[i].transform.position);
            }
            else if(i == flowers.Count - 1)
            {
                Handles.DrawLine(flowers[i - 1].transform.position, flowers[i].transform.position);

                Handles.color = new Color32(255, 255, 255, 255);
                Handles.DrawWireDisc(flowers[i].transform.position, Vector3.up, 1f);
                Handles.color = new Color32(0, 0, 150, 50);
                Handles.DrawSolidArc(flowers[i].transform.position, Vector3.up, Vector3.right, 360f, 1f);
            }
            else
            {
                Handles.DrawLine(flowers[i - 1].transform.position, flowers[i].transform.position);
            }
        }

        Handles.color = new Color32(255, 255, 255, 255);
        Handles.DrawWireDisc(transform.position, Vector3.up, 1f);
        Handles.color = new Color32(0, 0, 150, 50);
        Handles.DrawSolidArc(transform.position, Vector3.up, Vector3.right, 360f, 1f);
    }
#endif
}


#if UNITY_EDITOR
[CustomEditor(typeof(FlowerPath)), CanEditMultipleObjects]
[ExecuteInEditMode]
public class FlowerPathEditor : Editor
{
	public override void OnInspectorGUI()
	{
        DrawDefaultInspector();

        FlowerPath path = (FlowerPath)target;

        if(path.flowers.Count < 0)
        {
            EditorGUILayout.HelpBox("Please add some GameObject inside the flowers array.", MessageType.Warning);
        }
        else
        {
            GUILayout.Label("Tools");
            if(GUILayout.Button("Copy & Add"))
            {
                GameObject newFlower = Instantiate(path.GetLastElement(), path.GetLastElement().transform.position + new Vector3(0f, 0f, 2f), Quaternion.identity);
                newFlower.transform.rotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);
                newFlower.name = "Flower";
                newFlower.transform.SetParent(path.transform);
                path.flowers.Add(newFlower);
            }
            if(GUILayout.Button("Remove Last"))
            {
                DestroyImmediate(path.flowers[path.flowers.Count - 1]);
                path.flowers.RemoveAt(path.flowers.Count - 1);
            }
            if(GUILayout.Button("Clean list"))
            {
                for(int i = 0; i < path.flowers.Count; i++)
                {
                    if(path.flowers[i] == null) path.flowers.RemoveAt(i);
                }
            }
        }
	}


    public void OnSceneGUI()
    {
        FlowerPath path = (FlowerPath)target;

        if(path.flowers.Count > 0)
        {
            path.flowers[0].transform.position = path.transform.position;

            for(int i = 0; i < path.flowers.Count; i++)
            {
                if(i != 0 && path.flowers[i] != null)
                    path.flowers[i].transform.position = Handles.PositionHandle(path.flowers[i].transform.position, Quaternion.identity);
            }
        }
    }
}
#endif