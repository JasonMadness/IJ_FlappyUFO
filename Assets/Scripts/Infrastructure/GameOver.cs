using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverHUD;

    public void ShowHUD()
    {
        _gameOverHUD.SetActive(true);
    }
}
