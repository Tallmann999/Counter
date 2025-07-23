using UnityEngine;
using UnityEngine.Events;

public class InputReader : MonoBehaviour
{  
    public UnityEvent OnClickEvent;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnClickEvent?.Invoke(); 
        }
    }
}
