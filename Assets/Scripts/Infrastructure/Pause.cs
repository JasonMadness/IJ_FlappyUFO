using UnityEngine;

public class Pause : MonoBehaviour
{
    private float _pauseSpeed = 0f;
    private float _gameSpeed = 1f;

    public void On()
    {
        Time.timeScale = _pauseSpeed;
    }

    public void Off()
    {
        Time.timeScale = _gameSpeed;
    }
}
