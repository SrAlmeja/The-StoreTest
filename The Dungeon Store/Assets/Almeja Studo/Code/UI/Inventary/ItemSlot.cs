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

    [HideInInspector] [SerializeField] private string itemName;
    [HideInInspector] [SerializeField] public int quantity;
    [HideInInspector] [SerializeField] private string rarity;
    [HideInInspector] [SerializeField] private int sellPrice;
    [HideInInspector] [SerializeField] private Sprite itemSprite;
    [HideInInspector] [SerializeField] private string itemDescription;
    [HideInInspector] [SerializeField] public bool isFull;
    
    #endregion

    #region ItemSlot

    [SerializeField] private TMP_Text quantityText;
    [SerializeField] private Image itemImage;

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
    public Sprite EmptySprite;
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
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }

    public void OnLeftClick()
    {
        _inventoryManager.DeselectAllSlots();
        selectedShader.enabled = true;
        thisItemSelected = true;
        itemDescriptionImage.sprite = itemSprite;
        ItemDescriptionNameText.text = itemName;
        ItemDescriptionText.text = itemDescription;
        ItemDescriptionPriceText.text = sellPrice.ToString();
        if (itemDescriptionImage.sprite == null)
            itemDescriptionImage.sprite = EmptySprite;
    }

    public void OnRightClick()
    {
        
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


