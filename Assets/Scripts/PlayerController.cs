using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance = null;
    private readonly Dictionary<string, bool> _nullCheck = new Dictionary<string, bool>();
    
    private PlayerHealth _playerHealth;
    private PlayerInput _playerInput;
    private BaseMovement _playerMovement;
    
    public Subscribable<int> maxHealth;
    public Subscribable<int> curHealth;
    public Subscribable<float> speed;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        _playerHealth = GetComponent<PlayerHealth>();
        AddNullCheckList(_playerHealth, _playerHealth != null);
        if (_playerHealth != null) _playerHealth.Init(curHealth.GetValue(), maxHealth.GetValue()); 
        
        _playerInput = GetComponent<PlayerInput>();
        AddNullCheckList(_playerInput, _playerInput != null);
        if (_playerInput != null) _playerInput.Init(); 
        
        _playerMovement = GetComponent<BaseMovement>();
        AddNullCheckList(_playerMovement, _playerMovement != null);
        if (_playerMovement != null) _playerMovement.Init(speed.GetValue()); 
    }

    private void AddNullCheckList(System.Object obj, bool isNotNull)
    {
        _nullCheck.Add(obj.GetType().ToString(),isNotNull);
    }
    
    private bool CheckNull(System.Object obj)
    {
        return _nullCheck[obj.GetType().ToString()];
    }
    
    public void HealHealth(int heal)
    {
        if(!CheckNull(_playerHealth)) return;
        
        _playerHealth.HealHealth(heal);
    }
    
    public void TakeDamage(int damage)
    {
        if(!CheckNull(_playerHealth)) return;
        
        _playerHealth.TakeDamage(damage);
    }
}
