using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject gameOverPanel;
    public Text scoreText;
    
    private int score = 0;
    private const string MAIN_SCENE_NAME = "MainScene";
    private const string MENU_SCENE_NAME = "MenuScene";

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void GameOver()
    {
        ObstacleSpawner.instance.gameOver = true;
        StopScrolling();
        gameOverPanel.SetActive(true);
    }

    private static void StopScrolling()
    {
        TextureScroll[] scrollingObjects = FindObjectsOfType<TextureScroll>();

        foreach(TextureScroll item in scrollingObjects)
        {
            item.scroll = false;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(MAIN_SCENE_NAME);
    }
    public void Menu()
    {
        SceneManager.LoadScene(MENU_SCENE_NAME);
    }

    public void IncrementScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}