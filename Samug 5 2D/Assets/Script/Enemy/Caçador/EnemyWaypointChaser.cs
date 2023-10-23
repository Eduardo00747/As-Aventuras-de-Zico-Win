using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaypointChaser : MonoBehaviour
{
    public Transform target; // Refer�ncia ao transform do personagem
    public float moveSpeed = 2.0f; // Velocidade de movimento do inimigo

    private SpriteRenderer spriteRenderer; // Refer�ncia ao Sprite Renderer

    //Variaveis de anima��o
    private Animator animator;

    void Start()
    {
        // Obt�m a refer�ncia ao SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (target != null)
        {
            // Calcula a dire��o em dire��o ao personagem
            Vector3 direction = (target.position - transform.position).normalized;

            animator.SetBool("isRun", true);

            // Movimenta o inimigo na dire��o horizontal
            Vector3 movement = new Vector3(direction.x, 0, 0) * moveSpeed * Time.deltaTime;
            transform.Translate(movement);

            // Define FlipX com base na dire��o do movimento
            spriteRenderer.flipX = (direction.x < 0);
        }
    }
}
