using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _thrustForce = 5f;

    public event Action FallingStarted;

    private Rigidbody _rigidbody;
    private bool _wasFalling;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        bool isFalling = _rigidbody.velocity.y < 0f;

        if (isFalling && _wasFalling == false)
            FallingStarted?.Invoke();

        _wasFalling = isFalling;
    }

    public void Thrust()
    {
        _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0f, _rigidbody.velocity.z);
        _rigidbody.AddForce(Vector3.up * _thrustForce, ForceMode.Impulse);

        _wasFalling = false;
    }
}