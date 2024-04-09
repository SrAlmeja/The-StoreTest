using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private Canvas _inventoryPanel;
    private bool inventoryActive;
    private ItemFinder _itemFinder;
    private int quantity;

    private void Awake()
    {
        _itemFinder = FindObjectOfType<ItemFinder>();
        if (_itemFinder == null)
        {
            Debug.LogWarning("El itemFinder no se encuentra dentro de la escena");
        }
    }


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

    public void AddItem(ItemSO itemSo, int quantity)
    {
        _itemFinder.FindDuplicateItems(); 
        Debug.Log("Item Found: " + itemSo.ItemName + ", Rarity: " + itemSo.RarityTag + ", Quantity: " + quantity + " Value: " + itemSo.SellPrice);
    }
}
