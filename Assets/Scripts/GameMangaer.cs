using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Paddle playerPaddle;
    public Paddle opponentPaddle;
    public TMPro.TMP_Text playerScoreText;
    public TMPro.TMP_Text opponentScoreText;
    private int _playerScore;
    private int _opponentScore;
    public void PlayerScore()
    {
        _playerScore++;
        this.playerScoreText.text = _playerScore.ToString();
    }
    public void OpponentScore()
    {
        _opponentScore++;
        this.opponentScoreText.text = _opponentScore.ToString();
    }
    public void ResetGameObjects()
    {
        playerPaddle.ResetPosition();
        opponentPaddle.ResetPosition();
    }
}

