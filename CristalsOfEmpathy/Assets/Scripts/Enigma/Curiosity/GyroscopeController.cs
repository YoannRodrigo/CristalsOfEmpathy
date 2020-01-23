#region Using Directives
using UnityEngine;
#endregion

public class GyroscopeController : MonoBehaviour
{
    #region Member Variables
    private bool isGyroscopeEnabled;

    private Gyroscope gyroscope;

    private GameObject cameraContainer;

    private Quaternion rotation;
    #endregion

    #region Methods
    private void Start()
    {

        cameraContainer = new GameObject("Camera Container");
        cameraContainer.transform.position = transform.position;
        transform.SetParent(cameraContainer.transform);

        isGyroscopeEnabled = EnabledGyroscope();
    }

    private void Update()
    {
        if (isGyroscopeEnabled)
        {
            transform.localRotation = gyroscope.attitude * rotation;
        }
    }

    private bool EnabledGyroscope()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyroscope = Input.gyro;
            gyroscope.enabled = true;

            cameraContainer.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
            rotation = new Quaternion(0, 0, 1, 0);
            return true;
        }

        return false;
    }
    #endregion
}
