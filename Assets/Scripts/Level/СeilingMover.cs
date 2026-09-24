using UnityEngine;

public class СeilingMover : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _distanceBeforeReset = 1.2f;

    private float _initialPositionX;
    private float _currentPositionX;

    private void Awake()
    {
        _initialPositionX = transform.position.x;
    }

    private void Update()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);

        if (transform.position.x < _initialPositionX - _distanceBeforeReset)
        {
            ResetPosition();
        }
    }

    private void ResetPosition()
    {
        transform.position = new Vector3(_initialPositionX, transform.position.y, transform.position.z);
    }
}
