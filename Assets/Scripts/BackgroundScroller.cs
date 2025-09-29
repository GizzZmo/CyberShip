using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float scrollSpeed = 0.5f;
    private Vector2 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float newY = Mathf.Repeat(Time.time * scrollSpeed, 20);
        transform.position = startPosition + Vector2.down * newY;
    }
}
