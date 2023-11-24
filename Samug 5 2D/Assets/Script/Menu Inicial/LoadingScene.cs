using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadingScene : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip menuSelect;

    private void Start()
    {
        // Inicia a contagem regressiva para trocar de cena após 6 segundos
        StartCoroutine(LoadMenuAfterDelay(6f));
    }

    // Start is called before the first frame update
    public void SkipTutorial()
    {
        StartCoroutine(TutorialFase1("Fase 1"));
    }

    private IEnumerator LoadMenuAfterDelay(float delay)
    {
        // Aguarda o tempo especificado
        yield return new WaitForSeconds(delay);

        // Troca para a cena "Menu Inicial"
        SceneManager.LoadScene("Fase 1");
    }

    IEnumerator TutorialFase1(string sceneName)
    {
        audioSource.PlayOneShot(menuSelect);
        yield return new WaitForSeconds(menuSelect.length);
        SceneManager.LoadScene(sceneName);
        Debug.Log("Botão Skip");
    }
}
