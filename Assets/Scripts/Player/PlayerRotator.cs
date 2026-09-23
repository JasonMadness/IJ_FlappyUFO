using UnityEngine;

public class PlayerRotator : MonoBehaviour
{
    [SerializeField] private float _tiltUpAngle = 20f;
    [SerializeField] private float _tiltDownAngle = -35f;
    [SerializeField] private float _tiltUpSpeed = 250f;
    [SerializeField] private float _tiltDownSpeed = 40f;

    private float _targetReachedThreshold = 0.1f;
    private float _tiltSpeed;
    private float _targetTilt;

    private void Awake()
    {
        TiltDown();
    }

    private void Update()
    {
        float currentZ = transform.eulerAngles.z;
        float delta = Mathf.DeltaAngle(currentZ, _targetTilt);

        if (Mathf.Abs(delta) < _targetReachedThreshold && _targetTilt != _tiltDownAngle)
            TiltDown();

        float newZ = Mathf.MoveTowardsAngle(currentZ, _targetTilt, _tiltSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0f, 0f, newZ);
    }

    public void TiltUp()
    {
        _targetTilt = _tiltUpAngle;
        _tiltSpeed = _tiltUpSpeed;
    }

    public void TiltDown()
    {
        _targetTilt = _tiltDownAngle;
        _tiltSpeed = _tiltDownSpeed;
    }
}