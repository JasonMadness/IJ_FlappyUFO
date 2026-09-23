using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private PlayerRotator _playerRotator;

    private void OnEnable()
    {
        _playerInput.ThrustButtonPressed += _playerMover.Thrust;
        _playerInput.ThrustButtonPressed += _playerRotator.TiltUp;
    }

    private void OnDisable()
    {
        _playerInput.ThrustButtonPressed -= _playerMover.Thrust;
        _playerInput.ThrustButtonPressed -= _playerRotator.TiltUp;
    }
}
