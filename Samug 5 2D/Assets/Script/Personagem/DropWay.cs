using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropWay : MonoBehaviour
{
    public GameObject wayPointPrefab; // O prefab do WayPoint que voc� deseja instanciar

    private float spawnInterval = 0.6f; // O intervalo de tempo entre as inst�ncias
    private bool isSpawning = false; // Controla se o spawning est� ativo

    // Chamado quando algo entra na �rea de colis�o
    private IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o que entrou na �rea de colis�o tem a tag "Escada"
        if (other.CompareTag("Ladder") && !isSpawning)
        {
            // Atrasa o in�cio do spawning em 0.2 segundos
            yield return new WaitForSeconds(0.08f);

            // Inicia o spawning
            isSpawning = true;
            StartCoroutine(SpawnWayPoints());
        }
    }

    // Fun��o para spawnar o WayPoint em intervalos regulares
    IEnumerator SpawnWayPoints()
    {
        while (isSpawning)
        {
            // Instancia o prefab do WayPoint na posi��o atual do objeto DropWay
            Instantiate(wayPointPrefab, transform.position, Quaternion.identity);

            // Aguarda o intervalo de spawnInterval segundos
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    // Chamado quando algo sai da �rea de colis�o
    private void OnTriggerExit2D(Collider2D other)
    {
        // Verifica se o que saiu da �rea de colis�o tem a tag "Escada"
        if (other.CompareTag("Ladder"))
        {
            // Para o spawning
            isSpawning = false;
        }
    }
}
