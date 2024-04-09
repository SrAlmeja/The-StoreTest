using System;
using UnityEngine;

public class BankManager : MonoBehaviour
{
    #region Variable

    [HideInInspector] [SerializeField] public int gold = 0;

    #endregion
    
    public void AddGold(int amount)
    {
        gold += amount;
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
            gold -= amount;    
        }
    }
}
