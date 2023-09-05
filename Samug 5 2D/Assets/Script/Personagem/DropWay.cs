using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropWay : MonoBehaviour
{
    public GameObject wayPointPrefab; // O prefab do WayPoint que você deseja instanciar

    private float spawnInterval = 0.6f; // O intervalo de tempo entre as instâncias
    private bool isSpawning = false; // Controla se o spawning está ativo

    // Chamado quando algo entra na área de colisão
    private IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o que entrou na área de colisão tem a tag "Escada"
        if (other.CompareTag("Ladder") && !isSpawning)
        {
            // Atrasa o início do spawning em 0.2 segundos
            yield return new WaitForSeconds(0.08f);

            // Inicia o spawning
            isSpawning = true;
            StartCoroutine(SpawnWayPoints());
        }
    }

    // Função para spawnar o WayPoint em intervalos regulares
    IEnumerator SpawnWayPoints()
    {
        while (isSpawning)
        {
            // Instancia o prefab do WayPoint na posição atual do objeto DropWay
            Instantiate(wayPointPrefab, transform.position, Quaternion.identity);

            // Aguarda o intervalo de spawnInterval segundos
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    // Chamado quando algo sai da área de colisão
    private void OnTriggerExit2D(Collider2D other)
    {
        // Verifica se o que saiu da área de colisão tem a tag "Escada"
        if (other.CompareTag("Ladder"))
        {
            // Para o spawning
            isSpawning = false;
        }
    }
}
