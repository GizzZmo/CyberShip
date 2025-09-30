using UnityEngine;

/// <summary>
/// Controls enemy AI behavior including movement, shooting, and collision detection.
/// Enemies move downward and shoot at regular intervals.
/// </summary>
public class EnemyController : MonoBehaviour
{
    /// <summary>
    /// Movement speed of the enemy in units per second.
    /// </summary>
    public float moveSpeed = 2f;
    
    /// <summary>
    /// Time interval in seconds between enemy shots.
    /// </summary>
    public float shootInterval = 2f;
    
    /// <summary>
    /// Prefab for the enemy projectile to be instantiated when shooting.
    /// </summary>
    public GameObject enemyProjectilePrefab;
    
    /// <summary>
    /// Transform point where enemy projectiles will spawn from.
    /// </summary>
    public Transform firePoint;
    
    private float nextShootTime;
    private Transform player;

    /// <summary>
    /// Initializes the enemy by finding the player and setting up shooting timer.
    /// </summary>
    void Start()
    {
        // Find the player in the scene
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        
        nextShootTime = Time.time + shootInterval;
    }

    /// <summary>
    /// Called every frame. Handles movement and shooting behavior.
    /// </summary>
    void Update()
    {
        Move();
        Shoot();
    }

    /// <summary>
    /// Moves the enemy downward and destroys it when off-screen.
    /// </summary>
    void Move()
    {
        // Simple downward movement for space shooter enemies
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
        
        // Destroy enemy if it goes off screen (you can adjust this based on your camera setup)
        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Shoots enemy projectiles at regular intervals.
    /// </summary>
    void Shoot()
    {
        if (Time.time >= nextShootTime && enemyProjectilePrefab != null && firePoint != null)
        {
            // Create enemy projectile
            GameObject projectile = Instantiate(enemyProjectilePrefab, firePoint.position, firePoint.rotation);
            
            // Enemy shot sound
            AudioManager audioManager = FindObjectOfType<AudioManager>();
            if (audioManager != null)
                audioManager.PlayEnemyShot();
            
            // You can modify the projectile to move toward the player or just downward
            // For simplicity, we'll make it move downward
            
            nextShootTime = Time.time + shootInterval;
        }
    }

    /// <summary>
    /// Handles collision with player or player projectiles.
    /// </summary>
    /// <param name="other">The collider that the enemy collided with.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        // If enemy collides with player
        if (other.CompareTag("Player"))
        {
            // Damage player logic can be added here
            // For now, just destroy the enemy
            Destroy(gameObject);
        }
    }
}