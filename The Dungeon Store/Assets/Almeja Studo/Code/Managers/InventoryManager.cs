using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private Canvas _inventoryPanel;
    private bool inventoryActive;


    public void InventorySwitch()
    {
        if (inventoryActive)
        {
            _inventoryPanel.enabled = false;
            inventoryActive = false;
        }
        else
        {
            _inventoryPanel.enabled = true;
            inventoryActive = true;
        }
    }

    public void AddItem(ItemSO itemSo)
    {
        Debug.Log("Item Found: " + itemSo.ItemName + ", Rarity: " + itemSo.RarityTag + ", Quantity: " + itemSo.quantity + ", Value: " + itemSo.SellPrice);
    }
}
