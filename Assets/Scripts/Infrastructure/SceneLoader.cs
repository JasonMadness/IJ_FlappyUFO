using System;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public event Action Restarted;

    public void RestartGame()
    {
        string activeScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        UnityEngine.SceneManagement.SceneManager.LoadScene(activeScene);
        Restarted?.Invoke();
    }
}
