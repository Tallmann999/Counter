using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Counter))]
public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TextMeshProUGUI _textValue;

    private float _changeDuration = 1f;
    private Coroutine _coroutine;
    private float _currentDisplayValue;

    private void Start()
    {
        _currentDisplayValue = _counter.CurrentValue;
        _textValue.text = _currentDisplayValue.ToString();
    }

    private void OnEnable()
    {
        _counter.Changed += OnValueChanged;
    }

    private void OnDisable()
    {
        _counter.Changed -= OnValueChanged;
    }

    private void OnValueChanged(float value)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(SmoothChangeValue(value));
    }

    private IEnumerator SmoothChangeValue(float targetValue)
    {
        float startValue = _currentDisplayValue;
        float elapsed = 0f;

        while (elapsed < _changeDuration)
        {
            _currentDisplayValue = Mathf.Lerp(startValue, targetValue, _changeDuration);
            _textValue.text = _currentDisplayValue.ToString();
            elapsed += Time.deltaTime;
            yield return null;
        }

        _currentDisplayValue = targetValue;
        _textValue.text = _currentDisplayValue.ToString();
    }
}


