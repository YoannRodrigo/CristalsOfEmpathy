#region Using Directives
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#endregion

public class InteractiblePotion : MonoBehaviour
{
    #region Methods
    private void Update()
    {
        TouchRotation();
    }

    private void TouchRotation()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            if (Physics.Raycast(raycast, out RaycastHit raycastHit))
            {
                if (raycastHit.collider.gameObject == gameObject && !PauseMenu.IsOnPause())
                {
                    Debug.Log("Potion Touched");
                }
            }
        }
    }
    #endregion
}
