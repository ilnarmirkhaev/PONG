using UnityEngine;

public class BouncySurface : MonoBehaviour
{
    private const float BounceStrength = 5f;
    private AudioManager _audioManager;
    private bool _isPaddle;

    private void Awake()
    {
        _isPaddle = gameObject.name is "Player Paddle" or "Computer Paddle";
        _audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Ball ball = col.gameObject.GetComponent<Ball>();

        if (ball == null) return;
        
        _audioManager.Play(_isPaddle ? "PaddleHit" : "WallHit");
        
        Vector2 normal = col.GetContact(0).normal;
        ball.AddForce(-normal * BounceStrength);
    }
}
