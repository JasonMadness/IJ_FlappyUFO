using UnityEngine;

public class PlayerRotator : MonoBehaviour
{
    [SerializeField] private float _tiltUpAngle = 25f;
    [SerializeField] private float _tiltDownAngle = -45f;
    [SerializeField] private float _tiltUpSpeed = 100f;
    [SerializeField] private float _tiltDownSpeed = 30f;

    private float _tiltSpeed;

    private float _targetTilt;

    private void Awake()
    {
        TiltDown();
    }

    private void Update()
    {
        float currentZ = transform.eulerAngles.z;

        if (Mathf.Approximately(currentZ, _targetTilt))
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