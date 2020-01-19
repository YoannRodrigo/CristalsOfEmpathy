#region Using Directives

using UnityEngine;

#endregion

public abstract class InteractibleItem : MonoBehaviour
{
    #region Member Variables

    protected bool canBeTouch;
    private GameObject spawnedParticlesSystem;
    public GameObject nearParticlesSystem;

    #endregion

    #region Methods

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            if (Camera.main != null)
            {
                Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                if (Physics.Raycast(raycast, out RaycastHit raycastHit))
                    if (raycastHit.collider.gameObject == gameObject && !PauseMenu.IsOnPause())
                        OnTouch();
            }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!spawnedParticlesSystem) spawnedParticlesSystem = Instantiate(nearParticlesSystem, transform);
            canBeTouch = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (spawnedParticlesSystem) Destroy(spawnedParticlesSystem);
            canBeTouch = false;
        }
    }

    protected abstract void OnTouch();

    #endregion
}