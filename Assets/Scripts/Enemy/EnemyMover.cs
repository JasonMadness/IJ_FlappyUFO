using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;

    private void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * _speed);
    }
}
