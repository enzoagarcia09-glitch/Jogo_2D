using UnityEngine;
public class player : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D rb;

    private bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");   //Vai reconhecer o movimento horizontal

        rb.linearVelocity = new Vector2(moveHorizontal * speed, rb.linearVelocity.y); //Vai aplicar a velocidade horizontal
        
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded )
        {

            rb.AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse); //Vai adicionar o salto
        }
    }

    void OnCollisionEnter2D( Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; //Vai reconhecer quando o jogador cair no chão
        }
    }

     void OnCollisionExit2D(Collision2D collision)
    {

        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded= false; //Vai reconhecer quando o jogador cair no chão
        }   
    }

}
