using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointController : MonoBehaviour
{
    public float destroyDelay = 2f; // Tempo em segundos antes de destruir o objeto

    // Chamado quando o script � inicializado
    void Start()
    {
        // Destrua este objeto ap�s o atraso especificado
        Destroy(gameObject, destroyDelay);
    }
}
