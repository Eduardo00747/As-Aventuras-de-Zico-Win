using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect : MonoBehaviour
{
    // Chamado quando um Collider entra no Trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o Collider que entrou é o "Player"
        if (other.CompareTag("Player"))
        {
            // Destruir o objeto que possui este script
            //Destroy(gameObject);

            // Desativar o objeto em vez de destruí-lo
            gameObject.SetActive(false);
        }
    }

    /*private void OnDestroy()
    {
        // Obtém o componente EnemyController do pai (Inimigo) e inicia a perseguição
        EnemyController enemyController = transform.parent.GetComponent<EnemyController>();
        if (enemyController != null)
        {
            enemyController.StartChasing();
        }
    }*/

    private void OnDisable()
    {
        // Obtém o componente EnemyController do pai (Inimigo) e inicia a perseguição
        EnemyController enemyController = transform.parent.GetComponent<EnemyController>();
        if (enemyController != null)
        {
            enemyController.StartChasing();
        }

        // Ativa o objeto "BackPatrol" (assumindo que ele seja um filho do inimigo)
        Transform backPatrolTransform = transform.parent.Find("BackPatrulha");
        if (backPatrolTransform != null)
        {
            backPatrolTransform.gameObject.SetActive(true);
        }
    }
}