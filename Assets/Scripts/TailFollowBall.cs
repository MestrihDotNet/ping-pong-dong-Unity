using UnityEngine;

public class TailFollowBall : MonoBehaviour
{
    public Transform ball; // Reference to the ball (we'll set this in the Inspector)
    public float distanceFromBall = 1f; // The distance between the ball and the tail

    private Vector3 previousBallPosition; // To track the ball's previous position

    void Start()
    {
        // Initialize the previous position of the ball to the current position
        previousBallPosition = ball.position;
    }

    void Update()
    {
        // Calculate the movement direction of the ball
        Vector3 ballMovementDirection = ball.position - previousBallPosition;

        // If the ball is moving, adjust the tail's position
        if (ballMovementDirection.magnitude > 0)
        {
            // Normalize the movement direction (so it's a unit vector)
            Vector3 oppositeDirection = -ballMovementDirection.normalized;

            // Position the tail at a fixed distance opposite to the ball's movement direction
            transform.position = ball.position + oppositeDirection * distanceFromBall;
        }

        // Update the previous position to the current position for the next frame
        previousBallPosition = ball.position;
    }
}
