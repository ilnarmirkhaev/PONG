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

    [SerializeField] private int scoreToWin = 11;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject playField;

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
        if (_playerScore != scoreToWin && _computerScore != scoreToWin) return false;
        
        GameOver();
        return true;
    }

    private void GameOver()
    {
        playField.SetActive(false);
        gameOverMenu.SetActive(true);
        
        var resultText = gameOverMenu.transform.Find("Result Text");
        resultText.GetComponent<Text>().text = _playerScore > _computerScore ? "You win!" : "You lose :(";
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
}
