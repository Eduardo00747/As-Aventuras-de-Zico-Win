using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Esta é uma referência estática à instância do GameManager, permitindo que outros scripts acessem facilmente este objeto.

    private bool isPaused = false; // Uma variável que controla se o jogo está pausado ou não.

    public int quantidadeVida = 3; // Valor inicial da vida do jogador.

    public GameObject pauseObject; // Referência ao objeto "Pause" na HUD.

    private void Awake()
    {
        if (instance == null) // Verifica se já existe uma instância do GameManager.
        {
            instance = this; // Se não existir, esta instância se torna a instância única.
            DontDestroyOnLoad(gameObject); // Impede que o objeto GameManager seja destruído ao trocar de cena.
        }
        else
        {
            Destroy(gameObject); // Se já existir uma instância, destrói este objeto para evitar duplicatas.
        }

        if (pauseObject != null)
        {
            pauseObject.SetActive(false); // Garanta que o objeto "Pause" esteja inativo no início.
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) // Verifica se a tecla "Enter" foi pressionada.
        {
            TogglePause(); // Chama a função TogglePause para pausar ou despausar o jogo.
        }
    }

    void TogglePause()
    {
        isPaused = !isPaused; // Inverte o estado de pausa (se estava pausado, despausa, e vice-versa).

        if (isPaused)
        {
            Time.timeScale = 0f; // Pausa o jogo definindo o timeScale para zero. Isso congela todos os objetos que dependem do timeScale para sua animação ou movimento.
            if (pauseObject != null)
            {
                pauseObject.SetActive(true); // Ativa o objeto "Pause" na HUD quando o jogo está pausado.
            }
        }
        else
        {
            Time.timeScale = 1f; // Retoma o jogo definindo o timeScale de volta para 1. Isso faz com que o jogo retome seu ritmo normal.
            if (pauseObject != null)
            {
                pauseObject.SetActive(false); // Desativa o objeto "Pause" na HUD quando o jogo é retomado.
            }
        }
    }

    public void SetVida(int vida)
    {
        quantidadeVida = vida; // Esta função permite definir a quantidade de vida do jogador.
    }

    public int GetVida()
    {
        return quantidadeVida; // Esta função retorna a quantidade atual de vida do jogador.
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Esta função reinicia a cena atual, o que é útil para reiniciar o jogo.
    }
}