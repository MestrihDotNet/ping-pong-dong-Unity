using Unity.Mathematics;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 200.0f; // The constant speed of the ball
    protected Rigidbody2D _rigidbody;
    private Vector2 normalizedDirection; // Class-level variable for normalized direction
    private Vector2 currentVelocity; // Class-level variable for current velocity
    public TrailRenderer trail;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        AddStartingForce();
    }

    // Add the initial random force when the game starts
    public void AddStartingForce()
    {
        // Randomize the X direction, left or right using UnityEngine.Random
        float x = UnityEngine.Random.value < 0.5f ? -1.0f : 1.0f;

        // Randomize the Y direction, ensuring it’s not too vertical
        float y = UnityEngine.Random.value < 0.5f ? UnityEngine.Random.Range(-1.0f, -0.5f) : UnityEngine.Random.Range(0.5f, 1.0f);

        // Create direction vector and normalize it
        Vector2 direction = new Vector2(x, y).normalized;

        // Apply the force with the constant speed
        _rigidbody.linearVelocity = direction * this.speed;
    }

    void Update()
    {
        // Get the current velocity
        currentVelocity = _rigidbody.linearVelocity;

        // Calculate the current magnitude (speed)
        float currentSpeed = currentVelocity.magnitude;

        // If the speed is greater or less than the desired speed, adjust it
        if (currentSpeed != speed)
        {
            // Normalize the current velocity direction
            normalizedDirection = currentVelocity.normalized;

            // Set the new velocity with the desired speed
            _rigidbody.linearVelocity = normalizedDirection * speed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Wall"))
        {
            // Get the current velocity of the ball at the time of collision
            Vector2 currentVelocity = _rigidbody.linearVelocity;

            // Use Mathf.Abs() to get the absolute value of the x/y ratio
            if (Mathf.Abs(currentVelocity.x / currentVelocity.y) < 0.4f)
            {
                Debug.Log("too low");
                if (currentVelocity.x > 0 && currentVelocity.y != 0)
                {
                    // Increase the x velocity slightly
                    currentVelocity.x += 3;
                }
                else if (currentVelocity.x < 0 && currentVelocity.y != 0)
                {
                    // Decrease the x velocity slightly
                    currentVelocity.x -= 3;
                }

                // Apply the modified velocity back to the Rigidbody2D
                _rigidbody.linearVelocity = currentVelocity;
            }
        }
    }

}
