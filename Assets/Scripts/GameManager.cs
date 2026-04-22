using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Score")]
    public int score = 0;
    public int highScore = 0;

    [Header("Lives")]
    public int lives = 3;

    [Header("UI")]
    public Text scoreText;
    public Text highScoreText;
    public Text livesText;
    public GameObject gameOverPanel;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateUI();
        gameOverPanel.SetActive(false);
    }

    // 加分
    public void AddScore(int amount)
    {
        score += amount;

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }

        UpdateUI();
    }

    // 扣生命
    public void LoseLife()
    {
        lives--;

        if (lives <= 0)
        {
            GameOver();
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        scoreText.text = "Score: " + score;
        highScoreText.text = "High: " + highScore;
        livesText.text = "Lives: " + lives;
    }

    void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    // 重新開始
    public void RestartGame()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
