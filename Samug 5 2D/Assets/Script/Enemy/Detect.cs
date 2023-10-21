using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect : MonoBehaviour
{
    public CacadorController cacadorController; // Referencia ao script do Ca�ador 


    // Chamado quando um Collider entra no Trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o Collider que entrou � o "Player"
        if (other.CompareTag("Player"))
        {
            cacadorController.enabled = false;

            // Desativar o objeto em vez de destru�-lo
            gameObject.SetActive(false);
        }
    }


    private void OnDisable()
    {

        // Ativa o objeto "BackPatrol" (assumindo que ele seja um filho do inimigo)
        Transform backPatrolTransform = transform.parent.Find("BackPatrulha");
        if (backPatrolTransform != null)
        {
            backPatrolTransform.gameObject.SetActive(true);
        }
    }
}