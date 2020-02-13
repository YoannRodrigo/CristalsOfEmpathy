using UnityEngine;
public abstract class InteractibleItem : MonoBehaviour
{
    protected bool canBeTouch;
    public GameObject particlePrefab;
    protected ParticleSystem particle;

    public virtual void Start()
    {
        if(particlePrefab != null)
        {
            particle = Instantiate(particlePrefab, transform).GetComponent<ParticleSystem>();
            particle.Stop();
        }
    }

    private void Update()
    {
        if(!canBeTouch) return;

        if(Application.isEditor)
        {
            if(Input.GetMouseButtonDown(0))
            {
                if(Check(Input.mousePosition)) OnTouch();
            }
        }
        else
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                if(Check(Input.GetTouch(0).position)) OnTouch();
            }
        }
    }

    private bool Check(Vector2 position)
    {
        if (Camera.main != null)
        {
            Ray raycast = Camera.main.ScreenPointToRay(position);
            if (Physics.Raycast(raycast, out RaycastHit raycastHit))
            {
                if (raycastHit.collider.gameObject == gameObject && !PauseMenu.IsOnPause()) 
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }
        else return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) Enter();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) Exit();
    }

    protected abstract void OnTouch();
    protected virtual void Enter()
    {
        if (particle) particle.Play();
        canBeTouch = true;
        LevelManager.instance.player.look.FocusOn(gameObject.transform);
    }
    protected virtual void Exit()
    {
        if (particle) particle.Stop();
        canBeTouch = false;
        LevelManager.instance.player.look.LooseFocus();
    }
}