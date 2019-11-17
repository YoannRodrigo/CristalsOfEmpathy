#region Using Directives
using UnityEngine;
#endregion

public class FlyablePnj : MonoBehaviour
{
    #region Member Variables
    public float targetSpeed = 0.1f;
    private Vector3 targetNewPosition;
    #endregion

    #region Methods
    private void Start()
    {
        PositionChanged();
    }
    private void Update()
    {
        if (Vector2.Distance(transform.position, targetNewPosition) < 1)
        {
            PositionChanged();
        }
        transform.position = Vector3.Lerp(transform.position, targetNewPosition, Time.deltaTime * targetSpeed);
    }

    private void PositionChanged()
    {
        // OR HARDCODED FOR TEST PURPOST => targetNewPosition = new Vector3(Random.Range(-5f, 1f), Random.Range(4.5f, 5f), Random.Range(6f, 9.5f));

        targetNewPosition = new Vector3(Random.Range(transform.position.x - 1f, transform.position.x + 1f), Random.Range(transform.position.y - 0.5f, transform.position.y + 0.5f), Random.Range(transform.position.z - 1f, transform.position.z + 1f));
    }
    #endregion
}
