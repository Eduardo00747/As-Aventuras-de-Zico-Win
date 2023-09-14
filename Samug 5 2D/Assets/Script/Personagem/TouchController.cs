using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    private int auxDirecaoX; // Direção horizontal
    private int auxDirecaoY; // Direção vertical
    private int auxJump;
    private float jumpForce = 3.5f; // Força do pulo
    private bool canJump;    // Indica se o jogador pode pular
    private float speed;

    private Rigidbody2D rb; // Referência ao Rigidbody2D do personagem

    private bool isLadder; // Indica se o jogador está subindo na escada

    // Start is called before the first frame update
    void Start()
    {
        speed = 3f;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (auxDirecaoX != 0)
        {
            transform.Translate(speed * Time.deltaTime * auxDirecaoX, 0, 0);
        }

        if(isLadder)
        {
            if (auxDirecaoY != 0)
            {
                //Aqui é a logica para a movimentação vertical 
                rb.velocity = new Vector2(0, auxDirecaoY * speed);
            }
        }

        if(canJump)
        {
            if (auxJump != 0)
            {
                //Aqui é a logica para a movimentação vertical 
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }

        if (auxDirecaoX < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (auxDirecaoX > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            isLadder = false;
        }
    }

    public void TouchHorizontal(int direcao)
    {
        auxDirecaoX = direcao;
    }

    public void TouchVertical(int direcaovertical)
    {
        auxDirecaoY = direcaovertical;
    }

    public void TouchJump(int direcaojump)
    {
        auxJump = direcaojump;
    }
}
