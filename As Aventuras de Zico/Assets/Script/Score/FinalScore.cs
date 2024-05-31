using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScore : MonoBehaviour
{
    public TMP_Text pontuacaoFinalText;

    void Start()
    {
        // Recupere a pontua��o salva nos PlayerPrefs
        int pontuacao = PlayerPrefs.GetInt("Pontuacao", 0);
        pontuacaoFinalText.text = "" + pontuacao.ToString();
    }

    // Método para obter a pontuação final
    public int GetPontuacao()
    {
        return PlayerPrefs.GetInt("Pontuacao", 0);
    }
}