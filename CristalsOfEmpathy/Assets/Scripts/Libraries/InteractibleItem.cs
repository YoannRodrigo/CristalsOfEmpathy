using UnityEngine;

public class InteractibleItem : MonoBehaviour
{
    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (Camera.main != null)
            {
                Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                if (Physics.Raycast(raycast, out RaycastHit raycastHit))
                {
                    if (raycastHit.collider.gameObject == gameObject)
                    {
                        Debug.Log("Touch");
                    }
                }
            }
        }
    }
}
