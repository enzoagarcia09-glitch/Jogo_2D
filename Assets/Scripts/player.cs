using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public float speed = 5f;

    [Header("Dash no ar")]
    public float dashSpeed = 15f;       // velocidade durante o dash
    public float dashDuration = 0.15f;  // duração do dash em segundos
    public KeyCode dashKey = KeyCode.LeftShift;

    private Rigidbody2D rb;

    private bool isGrounded = false;

    private bool canDash = true;        // recarrega ao tocar o chão
    private bool isDashing = false;
    private float dashTimer;
    private float facing = 1f;          // direção para onde o jogador olha (1 = direita, -1 = esquerda)
    private float originalGravity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalGravity = rb.gravityScale;
    }

    void Update()
    {
        // Durante o dash, o jogador só avança reto e ignora o resto do controle
        if (isDashing)
        {
            rb.linearVelocity = new Vector2(facing * dashSpeed, 0f);

            dashTimer -= Time.deltaTime;
            if (dashTimer <= 0f)
            {
                EndDash();
            }
            return;
        }

        float moveHorizontal = Input.GetAxis("Horizontal");   //Vai reconhecer o movimento horizontal

        if (moveHorizontal != 0f)
        {
            facing = Mathf.Sign(moveHorizontal); // guarda a última direção usada
        }

        rb.linearVelocity = new Vector2(moveHorizontal * speed, rb.linearVelocity.y); //Vai aplicar a velocidade horizontal

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse); //Vai adicionar o salto
        }

        // Dash: só no ar e uma vez por salto
        if (Input.GetKeyDown(dashKey) && !isGrounded && canDash)
        {
            StartDash();
        }
    }

    void StartDash()
    {
        isDashing = true;
        canDash = false;
        dashTimer = dashDuration;
        rb.gravityScale = 0f; // sem gravidade durante o dash
    }

    void EndDash()
    {
        isDashing = false;
        rb.gravityScale = originalGravity;
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; //Vai reconhecer quando o jogador estiver no chão
            canDash = true;    // recarrega o dash
        }

        if (collision.gameObject.CompareTag("Dano"))
        {
            SceneManager.LoadScene(0);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false; //Vai reconhecer quando o jogador não estiver no chão
        }
    }
}