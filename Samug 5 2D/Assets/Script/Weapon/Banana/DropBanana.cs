using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBanana : MonoBehaviour
{
    public GameObject cascoBananaPrefab; // Refer�ncia ao prefab do CascoBanana que voc� deseja instanciar.

    void Update()
    {
        // Verifica se a tecla "K" foi pressionada.
        if (Input.GetKeyDown(KeyCode.K))
        {
            // Instancia o prefab do CascoBanana na posi��o atual deste objeto.
            Instantiate(cascoBananaPrefab, transform.position, Quaternion.identity);
        }
    }
}
