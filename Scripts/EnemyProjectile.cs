using UnityEngine;

/// <summary>
/// Handles enemy projectile behavior including movement and player collision damage.
/// Enemy projectiles move downward toward the player and are automatically destroyed after a set lifetime.
/// </summary>
public class EnemyProjectile : MonoBehaviour
{
    /// <summary>
    /// Movement speed of the enemy projectile in units per second.
    /// </summary>
    public float speed = 5f;
    
    /// <summary>
    /// Time in seconds before the projectile is automatically destroyed.
    /// </summary>
    public float lifetime = 5f;
    
    /// <summary>
    /// Amount of damage this projectile deals to the player (currently uses lives system).
    /// </summary>
    public int damage = 1;

    /// <summary>
    /// Initializes the projectile and schedules its destruction.
    /// </summary>
    void Start()
    {
        // Destroy projectile after lifetime to prevent memory leaks
        Destroy(gameObject, lifetime);
    }

    /// <summary>
    /// Moves the projectile downward toward the player each frame.
    /// </summary>
    void Update()
    {
        // Move projectile downward (toward player)
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    /// <summary>
    /// Handles collision with the player or other objects.
    /// Damages the player on contact.
    /// </summary>
    /// <param name="other">The collider that this projectile collided with.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if projectile hits the player
        if (other.CompareTag("Player"))
        {
            // Damage player
            if (GameManager.Instance != null)
            {
                GameManager.Instance.PlayerTakeDamage();
            }
            
            // Hit damage sound
            AudioManager audioManager = FindObjectOfType<AudioManager>();
            if (audioManager != null)
                audioManager.PlayHitDamage();
            
            // Destroy projectile
            Destroy(gameObject);
        }
        // Destroy projectile if it hits any other collider (except enemies)
        else if (!other.CompareTag("Enemy") && !other.CompareTag("EnemyProjectile"))
        {
            Destroy(gameObject);
        }
    }
}