using UnityEngine;

/// <summary>
/// Handles player projectile behavior including movement, collision detection, and scoring.
/// Automatically destroys itself after a set lifetime to prevent memory leaks.
/// </summary>
public class Projectile : MonoBehaviour
{
    /// <summary>
    /// Movement speed of the projectile in units per second.
    /// </summary>
    public float speed = 10f;
    
    /// <summary>
    /// Time in seconds before the projectile is automatically destroyed.
    /// </summary>
    public float lifetime = 5f;
    
    /// <summary>
    /// Score points awarded to the player when this projectile destroys an enemy.
    /// </summary>
    public int scoreValue = 10;

    /// <summary>
    /// Initializes the projectile and schedules its destruction.
    /// </summary>
    void Start()
    {
        // Destroy projectile after lifetime to prevent memory leaks
        Destroy(gameObject, lifetime);
    }

    /// <summary>
    /// Moves the projectile forward each frame.
    /// </summary>
    void Update()
    {
        // Move projectile forward
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    /// <summary>
    /// Handles collision with other game objects.
    /// Destroys enemies on contact and awards score points.
    /// </summary>
    /// <param name="other">The collider that this projectile collided with.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if projectile hits an enemy
        if (other.CompareTag("Enemy"))
        {
            // Add score for destroying enemy
            if (GameManager.Instance != null)
            {
                GameManager.Instance.AddScore(scoreValue);
            }
            
            // Destroy enemy
            Destroy(other.gameObject);
            // Destroy projectile
            Destroy(gameObject);
        }
        // Destroy projectile if it hits any other collider
        else if (!other.CompareTag("Player") && !other.CompareTag("PlayerProjectile"))
        {
            Destroy(gameObject);
        }
    }
}