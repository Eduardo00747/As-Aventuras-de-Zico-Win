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
        //Botão de configuração 
        SceneManager.LoadScene("Configuração");
    }

    public void QuitGame()
    {
        // Sai do jogo (funciona somente no build executável)
        Application.Quit();
        Debug.Log("Jogo Fechado");
    }

    public void Sair()
    {
        //Caso o jogador esteja na tela de configuração 
        SceneManager.LoadScene("Menu Inicial");
    }
}
