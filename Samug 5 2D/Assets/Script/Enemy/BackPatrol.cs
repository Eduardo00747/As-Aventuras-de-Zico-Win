using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackPatrol : MonoBehaviour
{
    public GameObject detectObject; // Referência ao objeto "Detect"

    public EnemyController enemyController; // Referência ao script "EnemyController"



    // Esta função é chamada quando algo deixa a área de colisão
    private void OnTriggerExit2D(Collider2D other)
    {
        // Verifica se o que saiu da área de colisão tem a tag "Player"
        if (other.CompareTag("Player"))
        {
            // Desativa o objeto a qual este script está anexado
            gameObject.SetActive(false);

            // Ativa o objeto "Detect"
            detectObject.SetActive(true);

            // Define o "StartChasing" no script "EnemyController" como falso
            enemyController.StartChasing(false);

        }
    }
}