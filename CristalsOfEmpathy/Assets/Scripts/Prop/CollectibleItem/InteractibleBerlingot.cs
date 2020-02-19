using UnityEngine;

public class InteractibleBerlingot : InteractibleItem
{
    public GameObject berlingotItem;
    public Item item;

    protected override void OnTouch()
    {
        if (canBeTouch && berlingotItem.CompareTag("Berlingots") && TutorialManager.instance.isQuestActivated)
        {
            bool wasPickedUp = Inventory.instance.Add(item);
            if (wasPickedUp) Destroy(berlingotItem.gameObject);
        }
    }
}