using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public event Action ThrustPressed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ThrustPressed?.Invoke();
        }
    }
}