using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    Scene _spaceScene;

    void Awake()
    {
        _spaceScene = SceneManager.GetSceneByName("Space");
    }

    public void StartGame()
    {
        SceneManager.LoadScene(_spaceScene.name);
    }
}