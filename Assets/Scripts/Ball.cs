using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 200f;
    
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        ResetPosition();
        AddStartingForce();
    }

    public void ResetPosition()
    {
        _rigidbody.position = Vector3.zero;
        _rigidbody.velocity = Vector3.zero;
    }

    public void AddStartingForce()
    {
        StartCoroutine(AddStartingForceCoroutine());
    }

    private IEnumerator AddStartingForceCoroutine()
    {
        yield return new WaitForSeconds(1);
        
        float x = Random.value < 0.5f ? -1f : 1f;
        float y = Random.value < 0.5f ? Random.Range(-1f, -0.5f) :
                                        Random.Range(0.5f, 1f);
        
        Vector2 direction = new Vector2(x, y);
        AddForce(direction * speed);
    }

    public void AddForce(Vector2 force)
    {
        _rigidbody.AddForce(force);
    }
}
