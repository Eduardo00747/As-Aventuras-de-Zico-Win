using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBanana : MonoBehaviour
{
    public GameObject cascoBananaPrefab; // Referência ao prefab do CascoBanana que você deseja instanciar.

    void Update()
    {
        // Verifica se a tecla "K" foi pressionada.
        if (Input.GetKeyDown(KeyCode.K))
        {
            // Instancia o prefab do CascoBanana na posição atual deste objeto.
            Instantiate(cascoBananaPrefab, transform.position, Quaternion.identity);
        }
    }
}
