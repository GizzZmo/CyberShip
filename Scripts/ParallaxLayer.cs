using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
    [Tooltip("Scroll speed for this layer. Lower = slower movement.")]
    public float scrollSpeed = 0.1f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float newY = Mathf.Repeat(Time.time * scrollSpeed, 20);
        transform.position = startPosition + Vector3.down * newY;
    }
}
