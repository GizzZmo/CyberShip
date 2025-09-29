using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    [Header("Game Settings")]
    public int playerLives = 3;
    public int score = 0;
    public bool gameOver = false;
    
    [Header("Spawn Settings")]
    public GameObject enemyPrefab;
    public float enemySpawnInterval = 2f;
    public Transform[] spawnPoints;
    
    private float nextSpawnTime;
    
    void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
        nextSpawnTime = Time.time + enemySpawnInterval;
    }
    
    void Update()
    {
        if (!gameOver)
        {
            SpawnEnemies();
        }
    }
    
    void SpawnEnemies()
    {
        if (Time.time >= nextSpawnTime && enemyPrefab != null && spawnPoints.Length > 0)
        {
            // Choose random spawn point
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];
            
            // Spawn enemy
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            
            nextSpawnTime = Time.time + enemySpawnInterval;
        }
    }
    
    public void AddScore(int points)
    {
        score += points;
        // Update UI here
        Debug.Log("Score: " + score);
    }
    
    public void PlayerTakeDamage()
    {
        playerLives--;
        if (playerLives <= 0)
        {
            GameOver();
        }
        // Update UI here
        Debug.Log("Lives remaining: " + playerLives);
    }
    
    public void GameOver()
    {
        gameOver = true;
        Debug.Log("Game Over! Final Score: " + score);
        // Show game over screen
        Time.timeScale = 0f; // Pause game
    }
    
    public void RestartGame()
    {
        gameOver = false;
        playerLives = 3;
        score = 0;
        Time.timeScale = 1f; // Resume game
        // Reload scene or reset game state
    }
}