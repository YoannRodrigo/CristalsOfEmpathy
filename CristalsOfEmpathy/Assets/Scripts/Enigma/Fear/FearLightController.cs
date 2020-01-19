
using UnityEngine;

[RequireComponent(typeof(Light))]
[RequireComponent(typeof(CapsuleCollider))]

public class FearLightController : MonoBehaviour
{
    private Light spotLight;
    private CapsuleCollider capsuleCollider;
    // Start is called before the first frame update
    private void Start()
    {
        spotLight = GetComponent<Light>();
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.touchCount != 0)
        {
            OnTouchDown();
            UpdateLightPosition();
            
        }
        else
        {
            OnTouchUp();
        }
    }

    private void OnTouchDown()
    {
        spotLight.enabled = true;
        capsuleCollider.enabled = true;
    }

    private void OnTouchUp()
    {
        spotLight.enabled = false;
        capsuleCollider.enabled = false;
    }

    private void UpdateLightPosition()
    {
        if (Camera.main != null)
        {
            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            Vector3 onScreenPosition = raycast.GetPoint(0);
            transform.position = new Vector3(onScreenPosition.x,onScreenPosition.y,transform.position.z);
        }
    }
}
