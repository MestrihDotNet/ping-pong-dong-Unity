using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;
    public float speed = 10.0f;

    private SpriteRenderer _spriteRenderer;
    private Color _originalColor; // Store the original color of the paddle
    public float colorChangeDuration = 0.2f; // Duration for color to stay black

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        // Initialize SpriteRenderer and store original color
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _originalColor = _spriteRenderer.color; // Store the original color
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
            // Start the color change Coroutine
            StartCoroutine(ChangeColorTemporarily());
        }
    }

    private IEnumerator ChangeColorTemporarily()
    {
        // Change the color to black
        _spriteRenderer.color = Color.white;

        // Wait for the specified duration
        yield return new WaitForSeconds(colorChangeDuration);

        // Change the color back to the original
        _spriteRenderer.color = _originalColor;
    }
}
