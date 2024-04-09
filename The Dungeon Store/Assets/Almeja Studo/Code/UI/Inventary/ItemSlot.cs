using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    #region Variables

    [HideInInspector] [SerializeField] private string itemName;
    [HideInInspector] [SerializeField] private int quantity;
    [HideInInspector] [SerializeField] private string rarity;
    [HideInInspector] [SerializeField] private int sellPrice;
    [HideInInspector] [SerializeField] private Sprite Image;

    [SerializeField] private bool isFull;

    [SerializeField] private TMP_Text quantityText;
    [SerializeField] private Sprite Sprite;

    private InventoryManager _inventoryManager;
    #endregion

    public void AddItem(ItemSO itemSo)
    {
        this.itemName = itemSo.ItemName;
        this.quantity = itemSo.Quantity;
        this.itemName = itemSo.ItemName;
        this.itemName = itemSo.ItemName;
        this.itemName = itemSo.ItemName;
        
    }
}


