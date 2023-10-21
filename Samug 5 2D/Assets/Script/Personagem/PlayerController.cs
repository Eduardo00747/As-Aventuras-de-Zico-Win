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

    private SpriteRenderer spriteRenderer;

    //public GameObject escadaEnemyCima; // Referência ao objeto "Escada Enemy Cima"
    //public GameObject escadaEnemyBaixo; // Referência ao objeto "Escada Enemy Baixo"

    //Variaveis Escada
    public float climbSpeed = 3f; // Velocidade de subida na escada
    [SerializeField] private bool isClimbing; // Indica se o jogador está subindo na escada

    //Variaveis de animação
    private Animator animator;

    //Referencia as armas 
    public GameObject DropBanana; // Referência ao objeto HitBoxAtaque

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Obtém a referência do objeto "Throw Cruz"
        DropBanana = transform.Find("Drop Banana").gameObject;
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 moveDirection = new Vector2(horizontalInput, 0);

        rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);

        // Configura a variável de animação "isWalk" no Animator
        bool isWalk = Mathf.Abs(horizontalInput) > 0.1f;
        animator.SetBool("isWalk", isWalk);

        // Verificar se o jogador está se movendo para a esquerda e inverter o sprite
        if (horizontalInput < 0)
        {
            spriteRenderer.flipX = false;
        }
        // Verificar se o jogador está se movendo para a direita e restaurar a orientação do sprite
        else if (horizontalInput > 0)
        {
            spriteRenderer.flipX = true;
        }


        // Configura o parâmetro "isJump" na animação
        animator.SetBool("isJump", !isGrounded); // Inverte o estado do pulo (true quando não estiver no chão)

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
                animator.SetBool("isClimb", true);
                animator.SetBool("isWalk", false);

                // Ative o objeto "Escada Enemy Cima"
                //escadaEnemyCima.SetActive(true);

                // Ative o objeto "Escada Enemy Baixo"
                //escadaEnemyBaixo.SetActive(false);
            }
            // Se estiver pressionando para baixo, desça a escada
            else if (verticalInput < 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, -climbSpeed);
                animator.SetBool("isClimb", true);
                animator.SetBool("isWalk", false);

                // Desative o objeto "Escada Enemy Cima"
                //escadaEnemyCima.SetActive(false);

                // Ative o objeto "Escada Enemy Baixo"
                //escadaEnemyBaixo.SetActive(true);
            }
            // Se não estiver pressionando verticalmente, mantenha a velocidade vertical zero
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
            }
        }
    }

    private void LateUpdate()
    {
        // Verifique o valor de spriteRenderer.flipX
        float dropBananaOffsetX = spriteRenderer.flipX ? 0.41f : -0.55f;

        // Defina a posição X da DropBanana com base no valor calculado
        Vector3 dropBananaPos = DropBanana.transform.localPosition;
        dropBananaPos.x = dropBananaOffsetX;
        DropBanana.transform.localPosition = dropBananaPos;
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
            animator.SetBool("isClimb", false);
            animator.SetBool("isWalk", true);
            rb.gravityScale = 1; // Reativa a gravidade ao sair da escada
        }
    }
}