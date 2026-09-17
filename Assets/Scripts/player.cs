using UnityEngine;
public class player : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        rb.linearVelocity = new Vector2(moveHorizontal * speed, rb.linearVelocity.y);
    }
}
