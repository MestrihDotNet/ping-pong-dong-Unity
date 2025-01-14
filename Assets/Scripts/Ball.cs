using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 200.0f;
    protected Rigidbody2D _rigidbody;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        AddStartingForce();
    }

    private void AddStartingForce()
    {
        float x = Random.value < 0.5f ? -1.0f : 1.0f;
        //If true, x is set to -1.0f (left direction).
        //If false, x is set to 1.0f (right direction).
        //If false, x is set to 1.0f(right direction).
        float y = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) : Random.Range(0.5f, 1.0f);

        Vector2 direction = new Vector2(x, y);
        _rigidbody.AddForce(direction * this.speed);
    }
}
