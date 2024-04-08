using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsActions : MonoBehaviour
{
    private SceneController _sceneController;

    private void Awake()
    {
        _sceneController = FindObjectOfType<SceneController>();
        if (_sceneController == null)
        {
            Debug.LogWarning("El SceneController no se encuentra dentro de la escena");
        }
        
    }

    public void PressMeToChangeScene(string sceneName)
    {
        _sceneController.LoadScene(sceneName);
    }

    public void PressMeToOpenInventory()
    {
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
