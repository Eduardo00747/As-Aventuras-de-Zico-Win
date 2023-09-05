using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variaveis Controller
    public float moveSpeed = 5f;
    public float jumpForce = 10f; // Força do pulo
    private Rigidbody2D rb;
    private bool isGrounded;
    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;

    //Variaveis Escada
    public float climbSpeed = 3f; // Velocidade de subida na escada
    [SerializeField] private bool isClimbing; // Indica se o jogador está subindo na escada


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 moveDirection = new Vector2(horizontalInput, 0);

        rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        // Verifica se o jogador está na escada
        if (isClimbing)
        {
            float verticalInput = Input.GetAxis("Vertical");

            // Se estiver pressionando para cima, suba a escada
            if (verticalInput > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, climbSpeed);
            }
            // Se estiver pressionando para baixo, desça a escada
            else if (verticalInput < 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, -climbSpeed);
            }
            // Se não estiver pressionando verticalmente, mantenha a velocidade vertical zero
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            isClimbing = true;
            rb.gravityScale = 0; // Desativa a gravidade enquanto estiver na escada
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            isClimbing = false;
            rb.gravityScale = 1; // Reativa a gravidade ao sair da escada
        }
    }
}