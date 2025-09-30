using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [Tooltip("Scroll speed for this layer. Lower = slower movement.")]
    public float scrollSpeed = 0.5f;

    [Tooltip("The vertical distance after which the layer content repeats. This should match your sprite/texture height.")]
    public float repeatLength = 20f;

    private Vector2 startPosition;

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

    void Update()
    {
        float newY = Mathf.Repeat(Time.time * scrollSpeed, repeatLength);
        transform.position = startPosition + Vector2.down * newY;
    }
}
