using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{

    // Contagem de Banana
    public TMP_Text bananaScore; // Refer�ncia para o objeto de texto "Banana Score"
    public static int bananasColetadas = 0; // Contagem de cora��es coletados

    // Start is called before the first frame update
    void Start()
    {
        // Inicializar o objeto de texto com a contagem de cora��es
        UpdateBananaScoreText();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar se a colis�o ocorreu com a tag "Player" ou "Borda"
        if (other.CompareTag("Banana"))
        {

            // Incrementar a contagem de cora��es coletados
            bananasColetadas++;

            // Atualizar o objeto de texto com a nova contagem de cora��es
            UpdateBananaScoreText();
        }
    }

    private void UpdateBananaScoreText()
    {
        bananaScore.text = "= " + bananasColetadas.ToString();
    }
}