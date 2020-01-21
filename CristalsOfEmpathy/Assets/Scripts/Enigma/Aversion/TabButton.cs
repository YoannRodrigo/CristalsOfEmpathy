#region Using Directives

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#endregion

[RequireComponent(typeof(Image))]
public class TabButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    #region Member Variables

    public TabGroup tabGroup;

    public Image background;

    #endregion

    #region Methods

    public void OnPointerClick(PointerEventData eventData)
    {
        tabGroup.OnTabSelected(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tabGroup.OnTabEnter(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tabGroup.OnTabExit(this);
    }

    private void Start()
    {
        background = GetComponent<Image>();
        tabGroup.Subscribe(this);
    }

    #endregion
}