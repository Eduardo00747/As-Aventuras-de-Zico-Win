using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{

    // Contagem de Banana
    public TMP_Text bananaScore; // Referência para o objeto de texto "Banana Score"
    public static int bananasColetadas = 0; // Contagem de corações coletados

    // Start is called before the first frame update
    void Start()
    {
        // Inicializar o objeto de texto com a contagem de corações
        UpdateBananaScoreText();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar se a colisão ocorreu com a tag "Player" ou "Borda"
        if (other.CompareTag("Banana"))
        {

            // Incrementar a contagem de corações coletados
            bananasColetadas++;

            // Atualizar o objeto de texto com a nova contagem de corações
            UpdateBananaScoreText();
        }
    }

    private void UpdateBananaScoreText()
    {
        bananaScore.text = "= " + bananasColetadas.ToString();
    }
}