#region Using Directives

using UnityEngine;

#endregion

public class ThrowableTomato : MonoBehaviour
{
    #region Member Variables

    private Vector3 startTouchPosition;
    private Vector3 endTouchPosition;
    private Vector3 directionSwipeTouchPosition;

    private const float THROW_FORCE = 0.8f;
    private float timeSinceTouchStarted;
    private float timeInterval;

    private RaycastHit2D hit;

    private Rigidbody rb;

    private bool throwAllowed = true;
    private bool isTomatoTouched;

    #endregion

    #region Methods

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!throwAllowed && transform.localScale.x >= 0.4 && transform.localScale.y >= 0.4)
        {
            Vector2 actualScale = transform.localScale;

            actualScale.x -= 0.01f;
            actualScale.y -= 0.01f;

            transform.localScale = actualScale;
        }

        if (transform.localScale.x < 0.4 || transform.localScale.y < 0.4) Destroy(gameObject);


        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) OnTouch();

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) OnUnTouch();

        if (isTomatoTouched)
        {
            timeSinceTouchStarted += Time.deltaTime;
            endTouchPosition = new Vector3(Input.GetTouch(0).position.x,
                Input.GetTouch(0).position.y,
                0);
        }
    }

    private void OnTouch()
    {
        Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        if (Physics.Raycast(raycast, out RaycastHit raycastHit))
            if (raycastHit.collider.CompareTag("Tomato") && !isTomatoTouched)
            {
                startTouchPosition = new Vector3(Input.GetTouch(0).position.x,
                    Input.GetTouch(0).position.y,
                    0);
                timeSinceTouchStarted = 0;
                isTomatoTouched = true;
            }
    }

    private void OnUnTouch()
    {
        if (isTomatoTouched)
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            timeInterval = timeSinceTouchStarted;
            directionSwipeTouchPosition = endTouchPosition - startTouchPosition;
            Debug.DrawLine(endTouchPosition, startTouchPosition, Color.cyan, 30);
            rb.AddForce(directionSwipeTouchPosition * THROW_FORCE / timeInterval);
            throwAllowed = false;
            isTomatoTouched = false;
        }
    }

    #endregion
}