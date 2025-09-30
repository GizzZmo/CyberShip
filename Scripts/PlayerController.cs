using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject projectilePrefab;
    public Transform firePoint;

    void Update()
    {
        Move();
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveX, moveY) * moveSpeed * Time.deltaTime;
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