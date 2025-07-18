using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Counter))]
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Counter _counter;
    [SerializeField] private float _stepSize = 1f;
    [SerializeField] private float _changeInterval = 0.5f;

    private bool _isActive = true;
    private Coroutine _autoIncrementCoroutine;

    private void OnEnable()
    {
        _button.onClick.AddListener(ToggleAutoIncrement);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ToggleAutoIncrement);
        StopAutoIncrement();
    }

    private void ToggleAutoIncrement()
    {
        _isActive = !_isActive;

        if (_isActive)
        {
            _autoIncrementCoroutine = StartCoroutine(AutoIncrement());
        }
        else
        {
            StopAutoIncrement();
        }
    }

    private IEnumerator AutoIncrement()
    {
        bool isActive = true;

        while (isActive)
        {
            _counter.AddValue(_stepSize);
            yield return new WaitForSeconds(_changeInterval);
        }
    }

    private void StopAutoIncrement()
    {
        if (_autoIncrementCoroutine != null)
            StopCoroutine(_autoIncrementCoroutine);
    }
}
