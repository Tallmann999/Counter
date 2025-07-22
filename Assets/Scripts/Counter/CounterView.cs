using TMPro;
using UnityEngine;

[RequireComponent(typeof(Counter))]
public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TextMeshProUGUI _textValue;

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
        _textValue.text = value.ToString();
    }
}


