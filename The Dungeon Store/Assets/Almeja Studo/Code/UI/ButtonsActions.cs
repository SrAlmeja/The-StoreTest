using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsActions : MonoBehaviour
{
    private SceneController _sceneController;
    private InventoryManager _inventoryManager;

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

        #endregion
        
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
