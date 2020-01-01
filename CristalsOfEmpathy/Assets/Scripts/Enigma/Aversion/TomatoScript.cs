#region Member Variables
using UnityEngine;
#endregion

public class TomatoScript : MonoBehaviour
{
    #region Member Variables
    #endregion

    #region Methods
    private void OnCollisionEnter2D(Collision2D entity)
    {
        if (entity.gameObject.tag == "Maire")
        {
            Destroy(this.gameObject);
            Instantiate(this.gameObject, this.gameObject.transform.position, this.gameObject.transform.rotation); ;
        }
    }
    #endregion
}
