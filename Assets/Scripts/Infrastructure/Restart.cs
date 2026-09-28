using System;
using UnityEngine;

public class Restart : MonoBehaviour
{
    public Action Restarted;

    public void RestartGame()
    {
        string activeScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        UnityEngine.SceneManagement.SceneManager.LoadScene(activeScene);
        Restarted?.Invoke();
    }
}
