using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SalaryManager : MonoBehaviour
{
    #region Variables

    [SerializeField] private BooleanSO isInMenu;
    private BankManager _bankManager;

    private static SalaryManager _instance;

    public static SalaryManager Instance
    {
        get { return _instance; }
    }
    #endregion

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            Debug.LogWarning("Mas controladores de tipo SalaryManager se han encontrado en la escena");
            return;
        }
        _instance = this;
        DontDestroyOnLoad(this.gameObject);
        
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