using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float shootInterval = 2f;
    public GameObject enemyProjectilePrefab;
    public Transform firePoint;
    
    private float nextShootTime;
    private Transform player;

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

    void Update()
    {
        Move();
        Shoot();
    }

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

    void Shoot()
    {
        if (Time.time >= nextShootTime && enemyProjectilePrefab != null && firePoint != null)
        {
            // Create enemy projectile
            GameObject projectile = Instantiate(enemyProjectilePrefab, firePoint.position, firePoint.rotation);
            
            // You can modify the projectile to move toward the player or just downward
            // For simplicity, we'll make it move downward
            
            nextShootTime = Time.time + shootInterval;
        }
    }

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