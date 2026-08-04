using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int playerLives = 5;
    public int currentLevel = 1;
    public bool isGameOver = false;

    public TextMeshProUGUI livesText;
    public TextMeshProUGUI levelText;
    public GameObject gameOverPanel;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        if (livesText != null)
        {
            livesText.text = "Lives: " + playerLives;
        }
        if (levelText != null)
        {
            levelText.text = "Level: " + currentLevel;
        }
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    public void RemoveLife()
    {
        if(isGameOver)
        {
            return;
        }
        playerLives--;
        if (livesText != null)
        {
            livesText.text = "Lives: " + playerLives;
        }
        //livesText.text = "Lives: " + playerLives;

        if (playerLives <= 0)
        {
            GameOver();
        }
    }

    public void checkLevelUp(int score)
    {
        int newLevel = (score / 100) + 1;
        if (newLevel > currentLevel)
        {
            currentLevel = newLevel;
            levelText.text = "Level: " + currentLevel;
        }
    }

    public int score = 0;

    public void AddScore(int points)
    {
        if (isGameOver)
        {
            return;
        }

        score += points;
        checkLevelUp(score);
        UpdateSystemUI();
    }

    void UpdateSystemUI()
    {
        if (livesText != null)
        {
            livesText.text = "Lives: " + playerLives;
        }
        if (levelText != null)
        {
            levelText.text = "Level: " + currentLevel;
        }
    }

    void GameOver()
    {
        isGameOver = true;
        //gameOverPanel.SetActive(true);
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Game Over Panel is not assigned.");
        }
    }

    void Update()
    {
        //if (isGameOver && Input.GetKeyDown(KeyCode.R))
        if (isGameOver && Keyboard.current != null && Keyboard.current.rKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void Addhealth()
    {
        if (isGameOver)
        {
            return;
        }
        playerLives++;
        UpdateSystemUI();
    }
}
