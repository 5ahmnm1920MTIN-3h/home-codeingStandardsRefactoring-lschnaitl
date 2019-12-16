using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private const string MAIN_SCENE_NAME = "MainScene";

    public void Play()
    {
        SceneManager.LoadScene(MAIN_SCENE_NAME);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
