using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamaged : MonoBehaviour, IDamageable
{
    [SerializeField] GameObject _gameOverMenu;

    public void TakeDamage()
    {
        Time.timeScale = 0;
        _gameOverMenu.SetActive(true);
    }
}