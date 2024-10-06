using UnityEngine;
using UnityEngine.Events;
using System;

[Serializable]
public class Subscribable<T>
{
    [SerializeField] private T value;
    [HideInInspector] public Action<T> OnChanged;

    public T GetValue()
    {
        return value;
    }

    public void SetValue(T set)
    {
        value = set;
        OnChanged?.Invoke(set);
    }
}