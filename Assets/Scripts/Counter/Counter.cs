using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _currentValue;
    [SerializeField] private float _stepSize = 1f;
    [SerializeField] private float _changeInterval = 0.5f;

    public float CurrentValue => _currentValue;
    public event Action<float> Changed;

    private Coroutine _currentCoroutine;
    private bool _isActive = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ToggleCounting();
        }
    }

    private void ToggleCounting()
    {
        if (!_isActive)
        {
            _currentCoroutine = StartCoroutine(IncreasesValue());
            _isActive = true;
        }
        else
        {
            StopCoroutine(_currentCoroutine);
            _isActive = false;
        }
    }

    private IEnumerator IncreasesValue()
    {
        bool _isPlay = true;

        while (_isPlay)
        {
            AddValue(_stepSize);
            yield return new WaitForSeconds(_changeInterval);
        }
    }

    private void AddValue(float value)
    {
        _currentValue += value;
        Changed?.Invoke(_currentValue);
    }
}
