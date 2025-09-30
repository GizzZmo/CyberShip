
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject projectilePrefab;
    public Transform firePoint;

    void Update()
    {
        HandleMovement();
        HandleShooting();
    }

    void HandleMovement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(moveX, moveY).normalized * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        // Engine thrust sound
        if (moveX != 0 || moveY != 0)
        {
            AudioManager audioManager = FindObjectOfType<AudioManager>();
            if (audioManager != null && audioManager.engineThrust != null && !audioManager.engineThrust.isPlaying)
                audioManager.PlayEngineThrust();
        }
        else
        {
            AudioManager audioManager = FindObjectOfType<AudioManager>();
            if (audioManager != null && audioManager.engineThrust != null)
                audioManager.engineThrust.Stop();
        }
    }

    void HandleShooting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (projectilePrefab != null && firePoint != null)
        {
            Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            
            // Laser shot sound
            AudioManager audioManager = FindObjectOfType<AudioManager>();
            if (audioManager != null)
                audioManager.PlayLaserShot();
        }
    }
}
