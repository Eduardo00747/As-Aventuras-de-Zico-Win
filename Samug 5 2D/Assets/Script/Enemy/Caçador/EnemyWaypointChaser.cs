using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaypointChaser : MonoBehaviour
{
    public Transform target; // Referência ao transform do personagem
    public float moveSpeed = 2.0f; // Velocidade de movimento do inimigo
    private Rigidbody2D rb; // Referência ao Rigidbody2D

    private SpriteRenderer spriteRenderer; // Referência ao Sprite Renderer

    //Variaveis de animação
    private Animator animator;
    private bool canMove = true; // Variável para controlar se o inimigo pode se mover


    void Start()
    {
        // Obtém a referência ao SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>(); // Obtém a referência ao Rigidbody2D

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (canMove && target != null)
        {
            // Calcula a direção em direção ao personagem
            Vector3 direction = (target.position - transform.position).normalized;

            animator.SetBool("isRun", true);

            // Movimenta o inimigo na direção horizontal
            Vector3 movement = new Vector3(direction.x, 0, 0) * moveSpeed * Time.deltaTime;
            // Congela a posição Y do Rigidbody
            rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;

            transform.Translate(movement);

            // Define FlipX com base na direção do movimento
            spriteRenderer.flipX = (direction.x < 0);
        }
    }

    // Quando o inimigo colide com algo
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se o objeto tem a tag "Gaiola"
        if (collision.collider.CompareTag("Gaiola"))
        {
            // Define a variável para parar o movimento
            canMove = false;
            animator.SetBool("isRun", false);

            // Inicia uma função que reativará o movimento após 3 segundos
            Invoke("ResumeMovement", 3f);
        }
    }

    // Função para retomar o movimento
    private void ResumeMovement()
    {
        canMove = true;
    }

}