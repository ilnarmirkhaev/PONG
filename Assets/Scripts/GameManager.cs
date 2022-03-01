using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Ball ball;

    public Paddle playerPaddle;
    public Paddle computerPaddle;

    public Text playerScoreText;
    public Text computerScoreText;
    
    private int _playerScore;
    private int _computerScore;

    public void PlayerScores()
    {
        _playerScore++;
        SetScoreText(playerScoreText, _playerScore);
        
        if (!IsGameOver())
            ResetRound();
    }

    public void ComputerScores()
    {
        _computerScore++;
        SetScoreText(computerScoreText, _computerScore);
        
        if (!IsGameOver())
            ResetRound();
    }

    private bool IsGameOver()
    {
        if (_playerScore == 7)
        {
            Debug.Log("You Win!");
            ResetGame();
            return true;
        }

        if (_computerScore == 7)
        {
            Debug.Log("You Lose :(");
            ResetGame();
            return true;
        }

        return false;
    }

    private void ResetGame()
    {
        _playerScore = 0;
        _computerScore = 0;
        ResetScoreTexts();
        ResetRound();
    }

    private void ResetRound()
    {
        playerPaddle.ResetPositionAndVelocity();
        computerPaddle.ResetPositionAndVelocity();
        ball.ResetPosition();
        ball.AddStartingForce();
    }

    private static void SetScoreText(Text scoreText, int score)
    {
        scoreText.text = score < 10 ? '0' + score.ToString() : score.ToString();
    }

    private void ResetScoreTexts()
    {
        playerScoreText.text = "00";
        computerScoreText.text = "00";
    }
}
