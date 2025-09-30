using UnityEngine;

/// <summary>
/// Central game manager that controls game state, scoring, lives, and enemy spawning.
/// Implements singleton pattern for global access throughout the game.
/// </summary>
public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Singleton instance of the GameManager accessible from anywhere in the game.
    /// </summary>
    public static GameManager Instance;
    
    [Header("Game Settings")]
    /// <summary>
    /// Number of lives the player has remaining.
    /// </summary>
    public int playerLives = 3;
    
    /// <summary>
    /// Current player score.
    /// </summary>
    public int score = 0;
    
    /// <summary>
    /// Indicates whether the game is over.
    /// </summary>
    public bool gameOver = false;
    
    [Header("Spawn Settings")]
    /// <summary>
    /// Prefab for enemies to be spawned.
    /// </summary>
    public GameObject enemyPrefab;
    
    /// <summary>
    /// Time interval in seconds between enemy spawns.
    /// </summary>
    public float enemySpawnInterval = 2f;
    
    /// <summary>
    /// Array of transform points where enemies can spawn.
    /// </summary>
    public Transform[] spawnPoints;
    
    private float nextSpawnTime;
    
    /// <summary>
    /// Initializes the singleton instance.
    /// Ensures only one GameManager exists across scenes.
    /// </summary>
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
    
    /// <summary>
    /// Sets up initial spawn timing.
    /// </summary>
    void Start()
    {
        nextSpawnTime = Time.time + enemySpawnInterval;
        
        // Play main theme music
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        if (audioManager != null)
            audioManager.PlayMainTheme();
    }
    
    /// <summary>
    /// Called every frame. Handles enemy spawning when game is active.
    /// </summary>
    void Update()
    {
        if (!gameOver)
        {
            SpawnEnemies();
        }
    }
    
    /// <summary>
    /// Spawns enemies at random spawn points at regular intervals.
    /// </summary>
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
    
    /// <summary>
    /// Adds points to the player's score.
    /// </summary>
    /// <param name="points">Number of points to add.</param>
    public void AddScore(int points)
    {
        score += points;
        // Update UI here
        Debug.Log("Score: " + score);
    }
    
    /// <summary>
    /// Reduces player lives by one and triggers game over if lives reach zero.
    /// </summary>
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
    
    /// <summary>
    /// Triggers the game over state and pauses the game.
    /// </summary>
    public void GameOver()
    {
        gameOver = true;
        Debug.Log("Game Over! Final Score: " + score);
        
        // Stop main theme and play game over music
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        if (audioManager != null)
        {
            if (audioManager.mainTheme != null)
                audioManager.mainTheme.Stop();
            audioManager.PlayGameOver();
        }
        
        // Show game over screen
        Time.timeScale = 0f; // Pause game
    }
    
    /// <summary>
    /// Restarts the game by resetting score, lives, and game state.
    /// </summary>
    public void RestartGame()
    {
        gameOver = false;
        playerLives = 3;
        score = 0;
        Time.timeScale = 1f; // Resume game
        // Reload scene or reset game state
    }
}