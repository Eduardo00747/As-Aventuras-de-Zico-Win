using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaypointChaser : MonoBehaviour
{
    public Transform target; // Referência ao transform do personagem
    public float moveSpeed = 2.0f; // Velocidade de movimento do inimigo

    private SpriteRenderer spriteRenderer; // Referência ao Sprite Renderer

    //Variaveis de animação
    private Animator animator;

    void Start()
    {
        // Obtém a referência ao SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (target != null)
        {
            // Calcula a direção em direção ao personagem
            Vector3 direction = (target.position - transform.position).normalized;

            animator.SetBool("isRun", true);

            // Movimenta o inimigo na direção horizontal
            Vector3 movement = new Vector3(direction.x, 0, 0) * moveSpeed * Time.deltaTime;
            transform.Translate(movement);

            // Define FlipX com base na direção do movimento
            spriteRenderer.flipX = (direction.x < 0);
        }
    }
}
