using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variaveis Controller
    public float moveSpeed = 5f;
    public float jumpForce = 10f; // For�a do pulo
    private Rigidbody2D rb;
    private bool isGrounded;
    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;

    private SpriteRenderer spriteRenderer;

    //public GameObject escadaEnemyCima; // Refer�ncia ao objeto "Escada Enemy Cima"
    //public GameObject escadaEnemyBaixo; // Refer�ncia ao objeto "Escada Enemy Baixo"

    //Variaveis Escada
    public float climbSpeed = 3f; // Velocidade de subida na escada
    [SerializeField] private bool isClimbing; // Indica se o jogador est� subindo na escada

    //Variaveis de anima��o
    private Animator animator;

    //Referencia as armas 
    public GameObject DropBanana; // Refer�ncia ao objeto HitBoxAtaque

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Obt�m a refer�ncia do objeto "Throw Cruz"
        DropBanana = transform.Find("Drop Banana").gameObject;
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 moveDirection = new Vector2(horizontalInput, 0);

        rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);

        // Configura a vari�vel de anima��o "isWalk" no Animator
        bool isWalk = Mathf.Abs(horizontalInput) > 0.1f;
        animator.SetBool("isWalk", isWalk);

        // Verificar se o jogador est� se movendo para a esquerda e inverter o sprite
        if (horizontalInput < 0)
        {
            spriteRenderer.flipX = false;
        }
        // Verificar se o jogador est� se movendo para a direita e restaurar a orienta��o do sprite
        else if (horizontalInput > 0)
        {
            spriteRenderer.flipX = true;
        }


        // Configura o par�metro "isJump" na anima��o
        animator.SetBool("isJump", !isGrounded); // Inverte o estado do pulo (true quando n�o estiver no ch�o)

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        // Verifica se o jogador est� na escada
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
            // Se estiver pressionando para baixo, des�a a escada
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
            // Se n�o estiver pressionando verticalmente, mantenha a velocidade vertical zero
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

        // Defina a posi��o X da DropBanana com base no valor calculado
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