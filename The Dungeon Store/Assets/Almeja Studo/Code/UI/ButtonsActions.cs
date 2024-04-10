using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsActions : MonoBehaviour
{
    private SceneController _sceneController;
    private InventoryManager _inventoryManager;
    private StoreManager _storeManager;

    
    [SerializeField] private ItemFinder _itemFinder;

    [SerializeField] private int _characterNumber;
    [SerializeField] private StringSO _dificulty;

    private void Awake()
    {
        #region Finders

        _sceneController = FindObjectOfType<SceneController>();
        if (_sceneController == null)
        {
            Debug.LogWarning("El SceneController no se encuentra dentro de la escena");
        }

        _inventoryManager = FindObjectOfType<InventoryManager>();
        if (_inventoryManager == null)
        {
            Debug.LogWarning("El InventoryManager no se encuentra dentro de la escena");
        }
        _storeManager = FindObjectOfType<StoreManager>();
        if (_inventoryManager == null)
        {
            Debug.LogWarning("El StoreManager no se encuentra dentro de la escena");
        }
        
        #endregion
    }

    public void PressToStartAdventure()
    {
        _itemFinder.GenerateItems(_dificulty.value, _characterNumber);
        _itemFinder.DropItemToInventory();
        _itemFinder.Print(_dificulty.value, _characterNumber);
    }

    public void PressToSellItem()
    {
        if (!string.IsNullOrEmpty(ItemSlot.selectedItemName))
        {
            _inventoryManager.RemoveItem(ItemSlot.selectedItemName);
            
            _inventoryManager.DeselectAllSlots();

            Debug.Log("Se ha vendido el artículo: " + ItemSlot.selectedItemName);
        }
        else
        {
            Debug.Log("No hay un artículo seleccionado para vender");
        }
    }
    
    public void PressMeToChangeScene(string sceneName)
    {
        _sceneController.LoadScene(sceneName);
    }

    public void PressMeToOpenInventory()
    {
        _inventoryManager.InventorySwitch();
        Debug.Log("Inventory has open");
    }
    public void PressMeToOpenStore()
    {
        _storeManager.StoreSwitch();
        Debug.Log("Inventory has open");
    }

    public void PressMeToCredits()
    {
        Debug.Log("Credits Open");
    }
    
    public void PressMeToExit()
    {
        _sceneController.Quit();
        Debug.Log("Saliendo del Juego");
    }
}
