using System;
using UnityEngine;

public class BankManager : MonoBehaviour
{
    #region Variable

    public IntSO gold;

    private static BankManager _instance;

    public static BankManager Instance
    {
        get { return _instance;  }
    }

    #endregion

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            Debug.LogWarning("Mas controladores de tipo BankManager se han encontrado en la escena");
            return;
        }
        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    
    public void AddGold(int amount)
    {
        gold.value += amount;
    }

    public void RemoveGold(int amount)
    {
        if (amount < 0)
        {
            Debug.LogWarning("Cannot remove negative gold amount.");
            return;
        }
        else
        {
            gold.value -= amount;    
        }
    }
}
