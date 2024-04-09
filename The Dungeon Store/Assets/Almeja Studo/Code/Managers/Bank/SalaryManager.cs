using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalaryManager : MonoBehaviour
{
    #region Variables
    private BankManager _bankManager;
    #endregion

    private void Awake()
    {
        _bankManager = FindObjectOfType<BankManager>();
        if (_bankManager == null)
        {
            Debug.LogWarning("El BankManager no se encuentra dentro de la escena");
        }
    }

    public void PayDayMethod(float payDay, int payment)
    {
        StartCoroutine(PayDay(payDay, payment));
    }
    
    private IEnumerator PayDay(float payDay, int payment)
    {
        while (true)
        {
            yield return new WaitForSeconds(payDay);
            _bankManager.AddGold(payment);
        }
    }
}