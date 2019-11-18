#region Using Directives

using UnityEngine;

#endregion

public class CameraMovement : MonoBehaviour
{
    // x = 0 / y = 25 / z = -10

    #region Member Variables

    public Transform target;
    private const float SMOOTH_SPEED = 0.125f;
    public Vector3 offset;

    #endregion

    #region Methods

    private void Start()
    {
        offset = new Vector3(0, 15, -10);
    }

    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, SMOOTH_SPEED);
        transform.position = smoothedPosition;
        transform.LookAt(target);
    }

    #endregion
}