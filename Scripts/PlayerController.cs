using UnityEngine;

/// <summary>
/// Controls player ship movement and shooting mechanics.
/// Handles player input for WASD/Arrow key movement and Space/Click shooting.
/// </summary>
public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// Movement speed of the player ship in units per second.
    /// </summary>
    public float moveSpeed = 5f;
    
    /// <summary>
    /// Prefab for the projectile that will be instantiated when shooting.
    /// </summary>
    public GameObject projectilePrefab;
    
    /// <summary>
    /// Transform point where projectiles will spawn from (usually front of ship).
    /// </summary>
    public Transform firePoint;

    /// <summary>
    /// Called every frame. Handles movement and shooting input.
    /// </summary>
    void Update()
    {
        Move();
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    /// <summary>
    /// Handles player movement based on input axes.
    /// Uses Horizontal and Vertical input axes for WASD/Arrow key movement.
    /// </summary>
    void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveX, moveY) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }

    /// <summary>
    /// Instantiates a projectile at the fire point when player shoots.
    /// Requires both projectilePrefab and firePoint to be assigned.
    /// </summary>
    void Shoot()
    {
        if (projectilePrefab != null && firePoint != null)
        {
            Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        }
    }
}