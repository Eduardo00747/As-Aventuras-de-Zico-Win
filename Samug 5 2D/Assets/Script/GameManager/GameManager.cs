using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Esta � uma refer�ncia est�tica � inst�ncia do GameManager, permitindo que outros scripts acessem facilmente este objeto.

    private bool isPaused = false; // Uma vari�vel que controla se o jogo est� pausado ou n�o.

    public int quantidadeVida = 3; // Valor inicial da vida do jogador.

    //N�o esqucer de colocar o time ...

    private void Awake()
    {
        if (instance == null) // Verifica se j� existe uma inst�ncia do GameManager.
        {
            instance = this; // Se n�o existir, esta inst�ncia se torna a inst�ncia �nica.
            DontDestroyOnLoad(gameObject); // Impede que o objeto GameManager seja destru�do ao trocar de cena.
        }
        else
        {
            Destroy(gameObject); // Se j� existir uma inst�ncia, destr�i este objeto para evitar duplicatas.
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) // Verifica se a tecla "Enter" foi pressionada.
        {
            TogglePause(); // Chama a fun��o TogglePause para pausar ou despausar o jogo.
        }
    }

    void TogglePause()
    {
        isPaused = !isPaused; // Inverte o estado de pausa (se estava pausado, despausa, e vice-versa).

        if (isPaused)
        {
            Time.timeScale = 0f; // Pausa o jogo definindo o timeScale para zero. Isso congela todos os objetos que dependem do timeScale para sua anima��o ou movimento.
        }
        else
        {
            Time.timeScale = 1f; // Retoma o jogo definindo o timeScale de volta para 1. Isso faz com que o jogo retome seu ritmo normal.
        }
    }

    public void SetVida(int vida)
    {
        quantidadeVida = vida; // Esta fun��o permite definir a quantidade de vida do jogador.
    }

    public int GetVida()
    {
        return quantidadeVida; // Esta fun��o retorna a quantidade atual de vida do jogador.
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Esta fun��o reinicia a cena atual, o que � �til para reiniciar o jogo.
    }
}
