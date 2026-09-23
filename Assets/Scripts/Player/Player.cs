using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerMover))]
public class Player : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private PlayerMover _playerMover;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerMover = GetComponent<PlayerMover>();
    }

    private void OnEnable()
    {
        _playerInput.ThrustButtonPressed += OnThrustButtonPressed;
    }

    private void OnDisable()
    {
        _playerInput.ThrustButtonPressed -= OnThrustButtonPressed;
    }

    private void OnThrustButtonPressed()
    {
        _playerMover.Thrust();
    }
}
