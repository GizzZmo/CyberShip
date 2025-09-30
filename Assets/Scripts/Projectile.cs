using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 5f;

    void Start()
    {
        Destroy(gameObject, lifetime); // Automatisk destruksjon etter noen sekunder
    }

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Her kan du legge til logikk for kollisjon med fiender
        if (other.CompareTag("Enemy"))
        {
            // Explosion sound when hitting enemy
            AudioManager audioManager = FindObjectOfType<AudioManager>();
            if (audioManager != null)
                audioManager.PlayExplosion();
            
            Destroy(other.gameObject); // Ødelegger fienden
            Destroy(gameObject);       // Ødelegger prosjektilen
        }
    }
}
