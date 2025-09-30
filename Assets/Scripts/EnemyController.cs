using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public int health = 1;

    void Update()
    {
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        
        // Hit damage sound
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        if (audioManager != null)
            audioManager.PlayHitDamage();
        
        if (health <= 0)
        {
            // Explosion sound
            if (audioManager != null)
                audioManager.PlayExplosion();
            
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerProjectile"))
        {
            TakeDamage(1);
            Destroy(other.gameObject);
        }
    }
}
