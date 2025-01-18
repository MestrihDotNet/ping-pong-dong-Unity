/*using UnityEngine;

public class TriggeringWall : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        // Find the GameManager object in the scene
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            if (gameObject.CompareTag("PlayerWall"))
            {
                gameManager.OpponentScore();

            }
            else if (gameObject.CompareTag("OpponentWall"))
            {
                gameManager.PlayerScore();
            }
        }
    }
}
*/
