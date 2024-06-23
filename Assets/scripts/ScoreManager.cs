using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI scoreText;
    private int score;

    private void Awake()
    {
        // Implement singleton pattern
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional: if you want to persist the ScoreManager across scenes
        }
    }

    private void Start()
    {
        ResetScore();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScore();
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
