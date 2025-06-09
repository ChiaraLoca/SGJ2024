using Inventory;
using UnityEngine;

public class LighterBehaviour : interactableBehaviour
{
    public override void Interact()
    {
        Debug.Log("Lighter interact");
        Info.Done = true;
        InventoryManager.instance.AddItem(Info.Name);
        gameObject.SetActive(false);

    }

}