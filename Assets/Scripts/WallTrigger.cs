using UnityEngine;

public class WallTrigger : MonoBehaviour
{
    // Reference to the GameController
    public GameController gameController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Only proceed if the ball collides with the wall
        if (other.CompareTag("Ball"))
        {
            // Notify the GameController
            gameController.HandleBallCollision(gameObject);
        }
    }
}
