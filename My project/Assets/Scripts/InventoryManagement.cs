using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManagement : MonoBehaviour
{
    public Inventory inventoryDatabase;
    public GameObject inventory;
    public Item[] items;
    private Character character;
    private DialogManagement dialogManagement;
    public void SetInitialCharacter(Character character)
    {
        this.character = character;
    }

    public void SetDialogManagement(DialogManagement dialogManagement)
    {
        this.dialogManagement = dialogManagement;
    }

    public void StartItems()
    {
        foreach (Item item in items)
        {
            item.SetQuantity(item.quantity);
        }
    }

    public void CloseInventory()
    {
        if (inventory != null)
        {
            Destroy(inventory);
        }
    }

    public void UpdateCharacterStatus(Item item)
    {
        if(character != null && item != null) 
        {
            if(item.quantity > 0)
            {
                character.IncreaseStatus(item);
                dialogManagement.SetSliderValues((1f-(float)character.Life/100f), (1f - (float)character.Energy/100f), (1f - (float)character.Satiation/100f));
                item.SetQuantity(--item.quantity);
            
            }
        }
    }
}
