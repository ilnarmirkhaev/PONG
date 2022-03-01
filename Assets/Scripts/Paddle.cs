using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed = 10f;
    protected Rigidbody2D Rigidbody;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    public void ResetPositionAndVelocity()
    {
        Rigidbody.position = new Vector2(Rigidbody.position.x, 0f);
        Rigidbody.velocity = Vector2.zero;
    }
}
