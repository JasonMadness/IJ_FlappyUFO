using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private KeyCode _thrustButtonKey = KeyCode.Space;

    public event Action ThrustButtonPressed;

    private void Update()
    {
        if (Input.GetKeyDown(_thrustButtonKey))
        {
            ThrustButtonPressed?.Invoke();
        }
    }
}