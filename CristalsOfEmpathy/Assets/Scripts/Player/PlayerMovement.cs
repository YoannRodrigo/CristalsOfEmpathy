#region Using Directives

using UnityEngine;

#endregion

public class PlayerMovement : MonoBehaviour
{
    #region Member Variables

    protected Joystick _joystick; /*Pourquoi "protected" il n'y pas de classe dérivée*/

    #endregion

    #region Methods

    private void Start()
    {
        _joystick = FindObjectOfType<Joystick>(); /* Mieux vaut un public qu'un "FindObjectOfType"*/
    }

    private void Update()
    {
        var _rigidbody = GetComponent<Rigidbody>(); /* Par de "var", on mets le type directement */
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * 5f, _rigidbody.velocity.y, _joystick.Vertical * 5f);
    }

    #endregion
}