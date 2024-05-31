using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    private void Start()
    {
        // Inicia a contagem regressiva para trocar de cena após 6 segundos
        StartCoroutine(LoadMenuAfterDelay(20f));
    }

    private IEnumerator LoadMenuAfterDelay(float delay)
    {
        // Aguarda o tempo especificado
        yield return new WaitForSeconds(delay);

        // Troca para a cena "Ranking"
        SceneManager.LoadScene("Ranking");
    }
}
