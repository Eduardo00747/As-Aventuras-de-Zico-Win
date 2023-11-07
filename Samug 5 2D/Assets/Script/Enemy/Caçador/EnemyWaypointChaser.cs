using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaypointChaser : MonoBehaviour
{
    public Transform target; // Refer�ncia ao transform do personagem
    public float moveSpeed = 2.0f; // Velocidade de movimento do inimigo
    private Rigidbody2D rb; // Refer�ncia ao Rigidbody2D

    private SpriteRenderer spriteRenderer; // Refer�ncia ao Sprite Renderer

    //Variaveis de anima��o
    private Animator animator;
    private bool canMove = true; // Vari�vel para controlar se o inimigo pode se mover


    void Start()
    {
        // Obt�m a refer�ncia ao SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>(); // Obt�m a refer�ncia ao Rigidbody2D

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (canMove && target != null)
        {
            // Calcula a dire��o em dire��o ao personagem
            Vector3 direction = (target.position - transform.position).normalized;

            animator.SetBool("isRun", true);

            // Movimenta o inimigo na dire��o horizontal
            Vector3 movement = new Vector3(direction.x, 0, 0) * moveSpeed * Time.deltaTime;
            // Congela a posi��o Y do Rigidbody
            rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;

            transform.Translate(movement);

            // Define FlipX com base na dire��o do movimento
            spriteRenderer.flipX = (direction.x < 0);
        }
    }

    // Quando o inimigo colide com algo
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se o objeto tem a tag "Gaiola"
        if (collision.collider.CompareTag("Gaiola"))
        {
            // Define a vari�vel para parar o movimento
            canMove = false;
            animator.SetBool("isRun", false);

            // Inicia uma fun��o que reativar� o movimento ap�s 3 segundos
            Invoke("ResumeMovement", 3f);
        }
    }

    // Fun��o para retomar o movimento
    private void ResumeMovement()
    {
        canMove = true;
    }

}