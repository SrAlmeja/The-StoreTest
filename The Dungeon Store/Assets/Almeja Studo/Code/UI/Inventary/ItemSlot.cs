using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    #region Variables

    [HideInInspector] [SerializeField] private string itemName;
    [HideInInspector] [SerializeField] private int quantity;
    [HideInInspector] [SerializeField] private string rarity;
    [HideInInspector] [SerializeField] private int sellPrice;
    [HideInInspector] [SerializeField] private Sprite itemSprite;

    [HideInInspector] [SerializeField] public bool isFull;

    [SerializeField] private TMP_Text quantityText;
    [SerializeField] private Image itemImage;

    private InventoryManager _inventoryManager;
    #endregion

    public void AddItem(ItemSO itemSo, int quantity)
    {
        this.itemName = itemSo.ItemName;
        this.quantity = quantity;
        this.rarity = itemSo.RarityTag;
        this.sellPrice = itemSo.SellPrice;
        this.itemSprite = itemSo.ItemImage;
        isFull = true;

        quantityText.text = quantity.ToString();
        quantityText.enabled = true;
        itemImage.sprite = itemSprite;
        

        UpdateUI();

    }

    private void UpdateUI()
    {
        quantityText.text = quantity.ToString();
    }
}


