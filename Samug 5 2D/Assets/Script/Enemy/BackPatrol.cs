using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackPatrol : MonoBehaviour
{
    public GameObject detectObject; // Refer�ncia ao objeto "Detect"

    public EnemyController enemyController; // Refer�ncia ao script "EnemyController"



    // Esta fun��o � chamada quando algo deixa a �rea de colis�o
    private void OnTriggerExit2D(Collider2D other)
    {
        // Verifica se o que saiu da �rea de colis�o tem a tag "Player"
        if (other.CompareTag("Player"))
        {
            // Desativa o objeto a qual este script est� anexado
            gameObject.SetActive(false);

            // Ativa o objeto "Detect"
            detectObject.SetActive(true);

            // Define o "StartChasing" no script "EnemyController" como falso
            enemyController.StartChasing(false);

        }
    }
}