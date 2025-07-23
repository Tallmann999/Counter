using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InputReader))]
public class Counter : MonoBehaviour
{
    [SerializeField] private float _currentValue;
    [SerializeField] private float _stepSize = 1f;
    [SerializeField] private float _changeInterval = 0.5f;
    [SerializeField] private InputReader _inputReader;

    public event Action<float> Changed;

    private Coroutine _currentCoroutine;
    private bool _isActive = false;
    private WaitForSeconds _waitForSeconds;

    private void OnEnable()
    {
        if (_inputReader != null)
        {
            _inputReader.Clicked += ToggleCounting;
        }
    }

    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(_changeInterval);
    }

    private void OnDisable()
    {
        if (_inputReader != null)
        {
            _inputReader.Clicked -= ToggleCounting;
        }
    }

    public void ToggleCounting()
    {
        if (!_isActive)
        {
            _currentCoroutine = StartCoroutine(IncreasesValue());
            _isActive = true;
        }
        else
        {
            if (_currentCoroutine != null)
            {
                StopCoroutine(_currentCoroutine);
                _isActive = false;
            }
        }
    }

    private IEnumerator IncreasesValue()
    {
        bool enabled = true;

        while (enabled)
        {
            AddValue(_stepSize);
            yield return _waitForSeconds;
        }
    }

    private void AddValue(float value)
    {
        _currentValue += value;
        Changed?.Invoke(_currentValue);
    }
}
