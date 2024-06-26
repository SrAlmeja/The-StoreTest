using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    #region Variables

    private static SceneController _instance;
    public static  SceneController Instance
    {
        get { return _instance; }
    }

    private PlayVerification _playVerification;
    
    #endregion

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            Debug.LogWarning("Mas controladores de tipo Scenetransition se han encontrado en la escena");
            return;
        }

        _instance = this;
        
        DontDestroyOnLoad(this.gameObject);
        _playVerification = FindObjectOfType<PlayVerification>();
        if (_playVerification == null)
        {
            Debug.LogWarning("El PlayVerification no se encuentra dentro de la escena");
        }
    }

    public void LoadScene(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
        _playVerification.Verified(sceneToLoad);
    }
    
    public void Pause()
    {
        Time.timeScale = 0f;
    }
    
    public void Resume()
    {
        Time.timeScale = 1f;
    }
    
    public void Quit()
    {
        Application.Quit();
    }
}