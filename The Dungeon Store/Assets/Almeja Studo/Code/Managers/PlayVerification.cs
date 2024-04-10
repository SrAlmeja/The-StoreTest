using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayVerification : MonoBehaviour
{
    public BooleanSO isInMainMenu;
    private SalaryManager _salaryManager;
    

    private static PlayVerification _instance;
    public static  PlayVerification Instance
    {
        get { return _instance; }
    }
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            Debug.LogWarning("Mas controladores de tipo PlayVerification se han encontrado en la escena");
            return;
        }
        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    
    public void Verified(string scenename)
    {
        Debug.Log("Verificando Escena");
        Debug.Log(isInMainMenu.value);
        if (scenename == "01MenuScene")
        {
            isInMainMenu.value = true;
        }
        else
        {
            isInMainMenu.value = false;

        }
    }
}
