using TMPro;
using UnityEngine;

[RequireComponent(typeof(Counter))]
public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TextMeshProUGUI _textValue;

    private float _currentDisplayValue;

    private void OnEnable()
    {
        _counter.Changed += OnValueChanged;
    }

    private void Start()
    {
        _currentDisplayValue = _counter.CurrentValue;
        _textValue.text = _currentDisplayValue.ToString();
    }

    private void OnDisable()
    {
        _counter.Changed -= OnValueChanged;
    }

    private void OnValueChanged(float value)
    {
        _textValue.text = value.ToString();
    }
}


