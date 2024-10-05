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
    
    [SerializeField] private HealthInfo healthData;
    public Action OnHealthChanged;
    public HealthInfo HealthData
    {
        get => healthData;
        set 
        {
            healthData = value;
            OnHealthChanged?.Invoke();
        }
    }
    
    [SerializeField] private float speed;
    public Action OnSpeedChanged;
    public float Speed
    {
        get => speed;
        set 
        {
            speed = value;
            OnSpeedChanged?.Invoke();
        }
    }

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
        if (_playerHealth != null) _playerHealth.Init(); 
        
        _playerInput = GetComponent<PlayerInput>();
        AddNullCheckList(_playerInput, _playerInput != null);
        if (_playerInput != null) _playerInput.Init(); 
        
        _playerMovement = GetComponent<BaseMovement>();
        AddNullCheckList(_playerMovement, _playerMovement != null);
        if (_playerMovement != null) _playerMovement.Init(); 
    }

    private void AddNullCheckList(System.Object obj, bool isNotNull)
    {
        _nullCheck.Add(obj.GetType().ToString(),isNotNull);
    }
    
    private bool CheckNull(System.Object obj)
    {
        return _nullCheck[obj.GetType().ToString()];
    }
    
    public void HealHealth(float heal)
    {
        if(!CheckNull(_playerHealth)) return;
        
        _playerHealth.HealHealth(heal);
        OnHealthChanged?.Invoke();
    }
    
    public void TakeDamage(float damage)
    {
        if(!CheckNull(_playerHealth)) return;
        
        _playerHealth.TakeDamage(damage);
        OnHealthChanged?.Invoke();
    }
}
