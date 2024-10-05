using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private HealthInfo _playerHealth;
    
    public void Init()
    {
        RefreshInfo();
        PlayerController.Instance.OnHealthChanged += RefreshInfo;
    }

    public void HealHealth(float heal)
    {
        _playerHealth.HealHealth(heal);
        PlayerController.Instance.HealthData = _playerHealth;
    }
    
    public void TakeDamage(float damage)
    {
        _playerHealth.DamageHealth(damage);
        PlayerController.Instance.HealthData = _playerHealth;
    }

    private void RefreshInfo()
    {
        _playerHealth = PlayerController.Instance.HealthData;
    }
}
