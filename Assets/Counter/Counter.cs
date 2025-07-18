using System;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _currentValue = 100f;

    public float CurrentValue => _currentValue;
    public event Action<float> Changed;

    public void AddValue(float value)
    {
        _currentValue += value;
        Changed?.Invoke(_currentValue);
    }
}
