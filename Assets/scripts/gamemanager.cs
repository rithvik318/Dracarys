using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public float initialGameSpeed = 5f;
    public float gameSpeedIncrease = 0.1f;
    public float gameSpeed { get; private set; }

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI hiscoreText;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private Button retryButton;

    private Player player;
    private Spawner spawner;

    private float score;
    public float Score => score;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Ensure the GameManager persists across scene loads
        }
    }

    private void Start()
    {
        NewGame();
    }

    public void NewGame()
    {
        Debug.Log("New Game Called"); // Log to check if NewGame is called
        ClearObstacles();

        score = 0f;
        gameSpeed = initialGameSpeed;
        enabled = true;

        player = FindObjectOfType<Player>();
        spawner = FindObjectOfType<Spawner>();

        player.gameObject.SetActive(true);
        spawner.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);

        Time.timeScale = 1f; // Ensure the game is running
        UpdateHiscore();
        UpdateScoreText();
    }

    public void GameOver()
    {
        Debug.Log("Game Over Called"); // Log to check if GameOver is called
        gameOverText.gameObject.SetActive(true);
        retryButton.gameObject.SetActive(true);
        Time.timeScale = 0f; // Stop the game
        UpdateHiscore();
    }

    public void RestartGame()
    {
        Debug.Log("Restart Game Called"); // Log to check if Restart is called
        Time.timeScale = 1f; // Resume the game
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
        player.Restart();
        NewGame();

    }

    private void Update()
    {
        gameSpeed += gameSpeedIncrease * Time.deltaTime;
        score += gameSpeed * Time.deltaTime;
        UpdateScoreText();
    }

    private void ClearObstacles()
    {
        Obstacle[] obstacles = FindObjectsOfType<Obstacle>();
        foreach (var obstacle in obstacles)
        {
            Destroy(obstacle.gameObject);
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = Mathf.FloorToInt(score).ToString("D5");
    }

    private void UpdateHiscore()
    {
        float hiscore = PlayerPrefs.GetFloat("hiscore", 0);

        if (score > hiscore)
        {
            hiscore = score;
            PlayerPrefs.SetFloat("hiscore", hiscore);
        }

        hiscoreText.text = Mathf.FloorToInt(hiscore).ToString("D5");
    }
}
