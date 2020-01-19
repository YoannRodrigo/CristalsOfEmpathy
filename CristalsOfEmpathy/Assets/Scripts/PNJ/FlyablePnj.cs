#region Using Directives

using UnityEngine;

#endregion

public class FlyablePnj : MonoBehaviour
{
    #region Member Variables

    public float targetSpeed = 0.15f;
    public TutorialManager tutorialManager;
    public GameObject endTutorialArea;
    private Transform targetTransform;
    private static bool _isPnjFlyingAllowed;
    private Vector3 flyNewPosition;

    #endregion

    #region Methods

    private void SetTargetTransform()
    {
        if (!targetTransform) targetTransform = FindObjectOfType<PlayerMovement>().gameObject.transform;
    }

    public void AllowPnjToFly(bool allow = true)
    {
        _isPnjFlyingAllowed = allow;
    }

    private void Start()
    {
        flyNewPosition = transform.position;
    }

    private void Update()
    {
        if (_isPnjFlyingAllowed && !tutorialManager.isQuestSubmitted)
        {
            SetTargetTransform();
            UpdateYPosition();
            UpdatePositionXz();
        }

        else if (_isPnjFlyingAllowed && tutorialManager.isQuestSubmitted)
        {
            SetTargetTransform();
            UpdateYPosition();
            FlyToEndArea();
        }
    }

    private void UpdateYPosition()
    {
        if (Vector2.Distance(transform.position, flyNewPosition) < 1) PositionChanged();
        transform.position = Vector3.Lerp(transform.position, flyNewPosition, Time.deltaTime * 1);
    }

    private void UpdatePositionXz()
    {
        if (!IsNearTarget(1.5f))
        {
            Vector3 position = transform.position;
            Vector3 position1 = targetTransform.position;
            position = Vector3.MoveTowards(position,
                new Vector3(position1.x, position.y, position1.z), 4.5f * Time.deltaTime);
            transform.position = position;
        }
    }

    private void FlyToEndArea()
    {
        if (IsNearTarget(50f))
        {
            Vector3 position = transform.position;
            Vector3 position1 = endTutorialArea.gameObject.transform.position;
            position = Vector3.MoveTowards(position,
                new Vector3(position1.x, position.y, position1.z), 4.5f * Time.deltaTime);
            transform.position = position;
        }
    }

    private bool IsNearTarget(float marge)
    {
        Vector3 position = transform.position;
        Vector3 position1 = targetTransform.position;

        return Mathf.Pow(position.x - position1.x, 2) + Mathf.Pow(position.z - position1.z, 2) < marge;
    }


    private void PositionChanged()
    {
        // OR HARDCODED FOR TEST PURPOST => targetNewPosition = new Vector3(Random.Range(-5f, 1f), Random.Range(4.5f, 5f), Random.Range(6f, 9.5f));

        Vector3 position = transform.position;
        flyNewPosition = new Vector3(position.x, Mathf.Max(Random.Range(position.y - 0.5f, position.y + 0.5f), 2f),
            position.z);
    }

    #endregion
}