using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BananaWeapon : MonoBehaviour
{
    // Contagem de Banana
    public TMP_Text bananaScore; // Refer�ncia para o objeto de texto "Banana Score"
    public int bananasColetadas = 0; // Contagem de cora��es coletados, SE FOR QUARDAR O VALOR USAR O STATIC

    // Start is called before the first frame update
    void Start()
    {
        // Inicializar o objeto de texto com a contagem de cora��es
        bananaScore.text = " 0";
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
            bananaScore.text = "= " + bananasColetadas.ToString();
        }
    }
}