using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamaged : MonoBehaviour, IDamagable
{
    Scene _activeScene;

    void Start()
    {
        _activeScene = SceneManager.GetActiveScene();
    }

    public void TakeDamage()
    {
        SceneManager.LoadScene(_activeScene.name);
    }
}