using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
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

    public Image selectedShader;
    public bool thisItemSelected;
    
    
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
    }

    public void OnRightClick()
    {
        
    }
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


