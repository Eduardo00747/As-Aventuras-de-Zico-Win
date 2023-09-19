using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private bool isPaused = false;

    public int quantidadeVida = 3; // Valor inicial da vida

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f; // Pausa o jogo definindo o timescale para zero
        }
        else
        {
            Time.timeScale = 1f; // Retoma o jogo definindo o timescale de volta para um
        }
    }

    public void SetVida(int vida)
    {
        quantidadeVida = vida;
    }

    public int GetVida()
    {
        return quantidadeVida;
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
