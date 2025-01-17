using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Ball ball;
    private int _playerScore;
    private int _opponentScore;
    public void PlayerScore()
    {
        _playerScore++;
        Debug.Log(_playerScore);
        this.ball.ResetPosition();
    }
    public void OpponentScore()
    {
        _opponentScore++;
        Debug.Log(_opponentScore);
        this.ball.ResetPosition();
    }

}

