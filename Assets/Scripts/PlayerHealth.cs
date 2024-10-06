using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int _playerMaxHealth;
    private int _playerCurHealth;
    
    public void Init(int cur, int max)
    {
        RefreshMaxHealthInfo(max);
        RefreshCurHealthInfo(cur);
        PlayerController.Instance.maxHealth.OnChanged += RefreshMaxHealthInfo;
        PlayerController.Instance.curHealth.OnChanged += RefreshCurHealthInfo;
    }
    
    private void RefreshMaxHealthInfo(int newMax)
    {
        _playerMaxHealth = newMax;
    }
    
    private void RefreshCurHealthInfo(int newCur)
    {
        _playerCurHealth = newCur;
    }

    public void HealHealth(int heal)
    {
        PlayerController.Instance.curHealth.SetValue(_playerCurHealth + heal < _playerMaxHealth 
            ? _playerCurHealth + heal 
            : _playerMaxHealth);
    }
    
    public void TakeDamage(int damage)
    {
        PlayerController.Instance.curHealth.SetValue(_playerCurHealth > damage 
            ? _playerCurHealth - damage
            : 0);
    }
}
