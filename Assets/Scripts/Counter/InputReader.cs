using UnityEngine;

[RequireComponent(typeof(Counter))]
public class InputReader : MonoBehaviour
{
    [SerializeField] private Counter _counter;

    private void Update()
    {
        ClickControl();
    }

    private void ClickControl()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _counter.ToggleCounting();
        }
    }
}
