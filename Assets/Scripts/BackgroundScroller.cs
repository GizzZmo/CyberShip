using UnityEngine;

/// <summary>
/// Scrolls background sprites vertically to create a scrolling space effect.
/// Similar to ParallaxLayer but uses Vector2 for 2D-specific positioning.
/// </summary>
public class BackgroundScroller : MonoBehaviour
{
    /// <summary>
    /// Scroll speed for this layer. Lower values result in slower movement.
    /// </summary>
    [Tooltip("Scroll speed for this layer. Lower = slower movement.")]
    public float scrollSpeed = 0.5f;

    /// <summary>
    /// The vertical distance after which the layer content repeats.
    /// This should match your sprite/texture height.
    /// </summary>
    [Tooltip("The vertical distance after which the layer content repeats. This should match your sprite/texture height.")]
    public float repeatLength = 20f;

    private Vector2 startPosition;

    /// <summary>
    /// Initializes the scroller and automatically calculates repeat length from sprite if available.
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
    /// Updates the background position each frame to create scrolling effect.
    /// </summary>
    void Update()
    {
        float newY = Mathf.Repeat(Time.time * scrollSpeed, repeatLength);
        transform.position = startPosition + Vector2.down * newY;
    }
}
