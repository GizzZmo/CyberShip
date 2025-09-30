using UnityEngine;

/// <summary>
/// Creates a parallax scrolling effect for background layers.
/// Scrolls the layer vertically and repeats it for infinite scrolling effect.
/// </summary>
public class ParallaxLayer : MonoBehaviour
{
    /// <summary>
    /// Scroll speed for this layer. Lower values result in slower movement.
    /// </summary>
    [Tooltip("Scroll speed for this layer. Lower = slower movement.")]
    public float scrollSpeed = 0.1f;

    /// <summary>
    /// The vertical distance after which the layer content repeats.
    /// This should match your sprite/texture height.
    /// </summary>
    [Tooltip("The vertical distance after which the layer content repeats. This should match your sprite/texture height.")]
    public float repeatLength = 20f;

    private Vector3 startPosition;

    /// <summary>
    /// Initializes the layer and automatically calculates repeat length from sprite if available.
    /// </summary>
    void Start()
    {
        startPosition = transform.position;

        // Automatically try to get repeatLength from SpriteRenderer
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null && sr.sprite != null)
        {
            repeatLength = sr.sprite.bounds.size.y;
        }
        else
        {
            Debug.LogWarning("No SpriteRenderer found or sprite assigned on " + gameObject.name + ". Ensure 'repeatLength' is set correctly in the Inspector.");
        }
    }

    /// <summary>
    /// Updates the layer position each frame to create scrolling effect.
    /// </summary>
    void Update()
    {
        float newY = Mathf.Repeat(Time.time * scrollSpeed, repeatLength);
        transform.position = startPosition + Vector3.down * newY;
    }
}
