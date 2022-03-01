using UnityEngine;

public class BouncySurface : MonoBehaviour
{
    public float bounceStrength;
    private void OnCollisionEnter2D(Collision2D col)
    {
        Ball ball = col.gameObject.GetComponent<Ball>();

        if (ball != null)
        {
            Vector2 normal = col.GetContact(0).normal;
            ball.AddForce(-normal * bounceStrength);
        }
    }
}
