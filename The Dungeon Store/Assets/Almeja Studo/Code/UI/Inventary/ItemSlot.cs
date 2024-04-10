using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    #region Variables

    #region ItemData

    [HideInInspector] public string itemName;
    [HideInInspector] public int quantity;
    [HideInInspector] public string rarity;
    [HideInInspector] public int sellPrice;
    [HideInInspector] public Sprite itemSprite;
    [HideInInspector] public string itemDescription;
    [HideInInspector] public bool isFull;
    
    #endregion

    #region ItemSlot

    [HideInInspector] public TMP_Text quantityText;
    [HideInInspector] public Image itemImage;
    
    [SerializeField] private Sprite emptySprite;
    public static string selectedItemName;
    public static int selectedItemSellPrice;
    public static int selecteItemQuantity;
    

    #endregion

    #region ItemDescriptionSlot

    public Image itemDescriptionImage;
    public TMP_Text ItemDescriptionNameText;
    public TMP_Text ItemDescriptionText;
    public TMP_Text ItemDescriptionPriceText;

    #endregion
    
    private InventoryManager _inventoryManager;
    public Image selectedShader;
    public bool thisItemSelected;
    
    [SerializeField] private int maxNumberOfItems;
    
    #endregion

    private void Awake()
    {
        _inventoryManager = FindObjectOfType<InventoryManager>();
        if (_inventoryManager == null)
        {
            Debug.LogWarning("El InventoryManager no se encuentra dentro de la escena");
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
    }

    public void OnLeftClick()
    {
        _inventoryManager.DeselectAllSlots();
        
        selectedItemName = itemName;
        selectedItemSellPrice = sellPrice;
        selecteItemQuantity = quantity;
        
        selectedShader.enabled = true;
        thisItemSelected = true;
        itemDescriptionImage.sprite = itemSprite;
        ItemDescriptionNameText.text = itemName;
        ItemDescriptionText.text = itemDescription;
        ItemDescriptionPriceText.text = sellPrice.ToString();
        if (itemDescriptionImage.sprite == null) ;
    }
    public int AddItem(ItemSO itemSo, int quantity)
    {
        if (isFull)
            return quantity;

        this.itemName = itemSo.ItemName;
        this.itemDescription = itemSo.ItemDescription;
        this.rarity = itemSo.RarityTag;
        this.sellPrice = itemSo.SellPrice;
        this.itemSprite = itemSo.ItemImage;
        itemImage.sprite = itemSprite;
        this.quantity += quantity;
        if (this.quantity >= maxNumberOfItems)
        {
            quantityText.text = quantity.ToString();
            quantityText.enabled = true;
            isFull = true;
            
            int extraItems = this.quantity - maxNumberOfItems;
            this.quantity = maxNumberOfItems;
            return extraItems;
        };

        quantityText.text = this.quantity.ToString();
        quantityText.enabled = true;

        return 0;
    }
    
}


