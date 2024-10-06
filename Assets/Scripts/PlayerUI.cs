using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Image playerHealthGauge;
    private int _maxHealth;
    private int _curHealth;

    private void Start()
    {
        RefreshMaxHealth(PlayerController.Instance.maxHealth.GetValue());
        RefreshCurHealth(PlayerController.Instance.curHealth.GetValue());
        PlayerController.Instance.maxHealth.OnChanged += RefreshMaxHealth;
        PlayerController.Instance.curHealth.OnChanged += RefreshCurHealth;
    }

    private void RefreshMaxHealth(int newMax)
    {
        _maxHealth = newMax;
        RefreshHealthGauge();
    }
    
    private void RefreshCurHealth(int newCur)
    {
        _curHealth = newCur;
        RefreshHealthGauge();
    }
    
    private void RefreshHealthGauge()
    {
        playerHealthGauge.fillAmount = (float)_curHealth / _maxHealth;
    }
}
