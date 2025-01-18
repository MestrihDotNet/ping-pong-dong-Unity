using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject BallPrefab;  // Reference to the Ball prefab
    private GameObject currentBall;

    public GameManager gameManager; // Reference to the GameManager for scoring

    void Start()
    {
        // Instantiate the initial ball when the game starts
        SpawnBall();
    }

    void Update() { }

    // This method will be called when a wall is hit
    public void HandleBallCollision(GameObject wall)
    {
        if (wall.CompareTag("PlayerWall"))
        {
            gameManager.OpponentScore(); // Call GameManager to handle score
        }
        else if (wall.CompareTag("OpponentWall"))
        {
            gameManager.PlayerScore(); // Call GameManager to handle score
        }

        Destroy(currentBall);  // Destroy the ball after the collision
        ResetRound(); // Reset the round by spawning a new ball
    }

    // Method to spawn a new ball at the center of the screen
    private void SpawnBall()
    {
        currentBall = Instantiate(BallPrefab, Vector3.zero, Quaternion.identity);
    }

    // Method to reset the round after scoring
    private void ResetRound()
    {
        // Spawn a new ball after the round ends
        SpawnBall();
    }
}
