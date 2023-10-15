using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        // Carrega a cena "Fase 1"
        SceneManager.LoadScene("Fase 1");
    }

    public void Options()
    {
        //Bot�o de configura��o 
        SceneManager.LoadScene("Configura��o");
    }

    public void QuitGame()
    {
        // Sai do jogo (funciona somente no build execut�vel)
        Application.Quit();
        Debug.Log("Jogo Fechado");
    }

    public void Sair()
    {
        //Caso o jogador esteja na tela de configura��o 
        SceneManager.LoadScene("Menu Inicial");
    }
}
