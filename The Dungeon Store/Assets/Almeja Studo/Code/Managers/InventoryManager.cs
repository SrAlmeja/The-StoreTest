using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    #region Variables

    [SerializeField] private Canvas _inventoryPanel;
    private bool inventoryActive;

    [SerializeField] private ItemSlot[] itemSlot;
    private ItemFinder _itemFinder;
    private int quantity;
    private BankManager _bankManager;

    #endregion
    
    private void Awake()
    {
        _itemFinder = FindObjectOfType<ItemFinder>();
        if (_itemFinder == null)
        {
            Debug.LogWarning("El itemFinder no se encuentra dentro de la escena");
        }
        
        _bankManager = FindObjectOfType<BankManager>();
        if (_bankManager == null)
        {
            Debug.LogWarning("El BankManager no se encuentra dentro de la escena");
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

    public int AddItem(ItemSO itemSo, int quantity)
    {
        _itemFinder.FindDuplicateItems(); //get iten quantity
        Debug.Log("Item Found: " + itemSo.ItemName + ", Rarity: " + itemSo.RarityTag + ", Quantity: " + quantity + " Value: " + itemSo.SellPrice);
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].isFull == false && itemSlot[i].name == name || itemSlot[i].quantity == 0)
            {
                int leftOverItems = itemSlot[i].AddItem(itemSo,quantity);
                if (leftOverItems > 0)
                    leftOverItems = AddItem(itemSo, leftOverItems);
                    return leftOverItems;
            }
        }
        return quantity;
    }
    
    public void DeselectAllSlots()
    {
        for (int i = 0;  i < itemSlot.Length; i++)
        {
            itemSlot[i].selectedShader.enabled = false;
            itemSlot[i].thisItemSelected = false;
        }
    }
    
    public void RemoveItem(string itemName)
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].itemName == itemName)
            {
                int totalPrice = itemSlot[i].sellPrice * itemSlot[i].quantity;
                
                itemSlot[i].itemName = null;
                itemSlot[i].quantity = 0;
                itemSlot[i].itemDescription = null;
                itemSlot[i].rarity = null;
                itemSlot[i].sellPrice = 0;
                itemSlot[i].itemSprite = null;
                itemSlot[i].isFull = false;
                itemSlot[i].quantityText.text = "";
                itemSlot[i].quantityText.enabled = false;
                itemSlot[i].itemImage.sprite = null;
                
                _bankManager.AddGold(totalPrice);
                break;
            }
        }
    }
}
