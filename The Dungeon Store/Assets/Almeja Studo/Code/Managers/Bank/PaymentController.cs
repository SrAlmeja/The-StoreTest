using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PaymentController : MonoBehaviour
{
    [SerializeField] private float payFrequency;
    [SerializeField] private int paymentAmount;
    private SalaryManager _salaryManager;
    private BankManager _bankManager;
    [SerializeField] private BooleanSO isInMenu;

[SerializeField] private TMP_Text goldText;
    [SerializeField] private IntSO gold;
    

    private void Awake()
    {
        _bankManager = FindObjectOfType<BankManager>();
        if (_bankManager == null)
        {
            Debug.LogWarning("El BankManager no se encuentra dentro de la escena");
        }
        _salaryManager = FindObjectOfType<SalaryManager>();
        if (_salaryManager == null)
        {
            Debug.LogWarning("El SalaryManager no se encuentra dentro de la escena");
        }
    }

    public void Start()
    {
        _salaryManager.PayDayMethod(payFrequency,paymentAmount);
    }

    private void FixedUpdate()
    {
        UpdateGoldText();
    }

    private void UpdateGoldText()
    {
        goldText.text = gold.value.ToString();
    }
    
}