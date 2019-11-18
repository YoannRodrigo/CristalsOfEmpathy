#region Using Directives

using UnityEngine;

[RequireComponent(typeof(Animator))]
#endregion

public class PauseAnimatorController : MonoBehaviour
{
    #region Member Variables
    
    private static readonly int isOnPause = Animator.StringToHash("isOnPause");
    private static readonly int toOption = Animator.StringToHash("toOption");
    
    
    private Animator animator;
    #endregion

    #region Methods

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    
    public void SlideUiIn()
    {
        animator.SetBool(isOnPause, true);
    }

    public void SlideToOption()
    {
        animator.SetBool(toOption, true);
    }

    public void SlideUiOut()
    {
        animator.SetBool(isOnPause, false);
    }
    
    #endregion
}