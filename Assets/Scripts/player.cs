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
        float moveHorizontal = Input.GetAxis("Horizontal");   //Vai reconhecer o movimento horizontal

        rb.linearVelocity = new Vector2(moveHorizontal * speed, rb.linearVelocity.y); //Vai aplicar a velocidade horizontal
        
        if(Input.GetKeyDown(KeyCode.Space))
        {

            rb.AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse); //Vai adiconar o salto
        }
    }
}
