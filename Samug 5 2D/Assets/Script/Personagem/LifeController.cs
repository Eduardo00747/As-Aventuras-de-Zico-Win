using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeController : MonoBehaviour
{
    public int maxHealth = 100;// Sa�de m�xima do jogador
    private int currentHealth;// Sa�de atual do jogador

    public TMP_Text vidaScore;// Refer�ncia ao texto para exibir a quantidade de vidas

    private int vidasRestantes;// Vari�vel para controlar o n�mero de vidas restantes

    void Start()
    {
        currentHealth = maxHealth;// Configura a sa�de atual para o valor m�ximo no in�cio
        vidasRestantes = GameManager.instance.GetVida();// Obt�m o valor da vida do GameManager
        vidaScore.text = "= " + vidasRestantes.ToString(); // Atualiza o texto da quantidade de vidas no UI
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;// Reduz a sa�de atual do jogador com base no dano recebido

        if (currentHealth <= 0)
        {
            Die();// Se a sa�de chegar a zero ou menos, chama a fun��o Die
        }
    }

    private void Die()
    {
        vidasRestantes--;// Subtrai 1 das vidas restantes

        vidaScore.text = "= " + vidasRestantes.ToString(); // Atualiza o texto da quantidade de vidas no UI

        if (vidasRestantes > 0)
        {
            GameManager.instance.SetVida(vidasRestantes); // Atualiza o valor da vida no GameManager
            GameManager.instance.ResetGame(); // Reinicia o jogo se ainda houver vidas restantes
        }
        else
        {
            // Se n�o houver mais vidas restantes, v� para a cena "Game Over"
            SceneManager.LoadScene("Game Over");

            // Redefina a contagem de bananas coletadas para 0
            ScoreController.bananasColetadas = 0;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Inimigo"))
        {
            TakeDamage(10);// Se colidir com um objeto com a tag "Inimigo", aplique 10 de dano
        }
    }
}
