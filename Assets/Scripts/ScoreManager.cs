using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public static ScoreManager Instance{get => instance;}

    public TextMeshProUGUI scoreText;
    private int score = 0;

    void Awake()
    {
        //Instance = this;
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateScoreUI();
    }

    public void AddScore(int points)
    {
        score += points;

        UpdateScoreUI();

        //GameManager.Instance.checkLevelUp(score);
        if (GameManager.Instance != null)
        {
            GameManager.Instance.checkLevelUp(score);
        }
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
        else
        {
            Debug.LogWarning("Score Text is not assigned.");
        }
    }
}
