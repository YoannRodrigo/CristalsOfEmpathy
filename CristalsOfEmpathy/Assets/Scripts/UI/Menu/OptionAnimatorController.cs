#region Using Directives

using UnityEngine;

[RequireComponent(typeof(Animator))]

#endregion

public class OptionAnimatorController : MonoBehaviour
{
    #region Member Variables

    private static readonly int isOnOption = Animator.StringToHash("isOnOption");

    public GameObject pauseMenu;
    public bool canBeDesactivated;

    private Animator animator;

    #endregion

    #region Methods

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (canBeDesactivated)
        {
            canBeDesactivated = false;
            pauseMenu.SetActive(true);
            pauseMenu.GetComponent<PauseAnimatorController>().SlideUiIn();
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        SlideUiIn();
    }

    private void SlideUiIn()
    {
        animator.SetBool(isOnOption, true);
    }

    public void SlideUiOut()
    {
        animator.SetBool(isOnOption, false);
    }

    #endregion
}