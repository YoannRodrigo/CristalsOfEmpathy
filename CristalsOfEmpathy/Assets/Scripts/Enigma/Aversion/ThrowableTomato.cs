#region Using Directives
using UnityEngine;

#endregion

public class ThrowableTomato : MonoBehaviour
{
    #region Member Variables
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    private Vector2 directionSwipeTouchPosition;

    [Range(0.05f, 100f)]
    public float throwForce = 0.3f;
    private float touchTimeStart;
    private float touchTimeFinish;
    private float timeInterval;

    private RaycastHit2D hit;

    private Rigidbody2D rb;

    private bool throwAllowed = true;
    #endregion

    #region Methods
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!throwAllowed && transform.localScale.x >= 0.5 && transform.localScale.y >= 0.5)
        {
            Vector2 actualScale = transform.localScale;

            actualScale.x -= 0.03f;
            actualScale.y -= 0.03f;

            transform.localScale = actualScale;
        }


        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            hit = Physics2D.Raycast(startTouchPosition, (Input.GetTouch(0).position));
            if (hit.collider != null && hit.collider.tag == "Tomato")
            {
                touchTimeStart = Time.time;

                startTouchPosition = Input.GetTouch(0).position;

                Debug.Log("touch");
            }

        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            hit = Physics2D.Raycast(startTouchPosition, (Input.GetTouch(0).position));
            if (hit.collider != null && hit.collider.tag == "Tomato")
            {
                touchTimeFinish = Time.time;

                timeInterval = touchTimeFinish - touchTimeStart;

                endTouchPosition = Input.GetTouch(0).position;

                directionSwipeTouchPosition = startTouchPosition - endTouchPosition;

                rb.isKinematic = false;
                rb.AddForce(-directionSwipeTouchPosition / timeInterval * throwForce);
                throwAllowed = false;


                Debug.Log("touch finished");
            }

        }
    }
    #endregion
}
