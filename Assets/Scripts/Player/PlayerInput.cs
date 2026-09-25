using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private KeyCode _thrustButtonKey = KeyCode.Space;
    [SerializeField] private KeyCode _shootButtonKey = KeyCode.Mouse0;

    public event Action ThrustButtonPressed;
    public event Action ShootButtonPressed;

    private void Update()
    {
        if (Input.GetKeyDown(_thrustButtonKey))
        {
            ThrustButtonPressed?.Invoke();
        }

        if (Input.GetKeyDown(_shootButtonKey))
        {
            ShootButtonPressed?.Invoke();
        }
    }
}