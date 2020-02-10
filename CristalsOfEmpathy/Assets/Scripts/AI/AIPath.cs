using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AIPath : MonoBehaviour
{
    [System.Serializable]
    public class Point
    {
        public Vector3 position;
        public float range;
    }

    public bool loop = true;
    public List<Point> points = new List<Point>();

    public Vector3 GetPosition(int id)
    {
        float range = points[id].range;
        return points[id].position + new Vector3(Random.Range(-range, range), 0f, Random.Range(-range, range));
    }
}