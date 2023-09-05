using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeController : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public TMP_Text vidaScore;

    // Variável para controlar o número de vidas restantes.
    private int vidasRestantes;

    void Start()
    {
        currentHealth = maxHealth;
        vidasRestantes = GameManager.instance.GetVida(); // Obtenha o valor da vida do GameManager
        vidaScore.text = "= " + vidasRestantes.ToString();
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Subtrai 1 das vidas restantes.
        vidasRestantes--;

        // Atualiza o texto da quantidade de vidas.
        vidaScore.text = "= " + vidasRestantes.ToString();

        // Se ainda houver vidas restantes, reinicie o jogo.
        if (vidasRestantes > 0)
        {
            GameManager.instance.SetVida(vidasRestantes); // Atualize o valor da vida no GameManager
            GameManager.instance.ResetGame(); // Reinicie o jogo
        }
        else
        {
            // Se não houver mais vidas restantes, vá para a cena "Game Over".
            SceneManager.LoadScene("Game Over");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Inimigo"))
        {
            TakeDamage(10);
        }
    }
}
