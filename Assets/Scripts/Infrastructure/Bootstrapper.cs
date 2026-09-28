using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private CollisionHandler _collisionHandler;
    [SerializeField] private Pause _pause;
    [SerializeField] private GameOver _gameOver;
    [SerializeField] private Restart _restart;

    private void OnEnable()
    {
        _collisionHandler.CollisionDetected += OnCollisionDetected;
        _restart.Restarted += OnRestarted;
    }

    private void OnDisable()
    {
        _collisionHandler.CollisionDetected -= OnCollisionDetected;
        _restart.Restarted -= OnRestarted;
    }

    private void OnCollisionDetected()
    {
        _pause.On();
        _gameOver.ShowHUD();
    }

    private void OnRestarted()
    {
        _pause.Off();
    }
}
