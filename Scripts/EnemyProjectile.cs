using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed = 5f;
    public float lifetime = 5f;
    public int damage = 1;

    void Start()
    {
        // Destroy projectile after lifetime to prevent memory leaks
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // Move projectile downward (toward player)
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

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