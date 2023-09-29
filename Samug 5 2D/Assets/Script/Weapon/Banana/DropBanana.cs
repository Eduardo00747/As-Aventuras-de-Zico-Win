using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBanana : MonoBehaviour
{
    public BananaWeapon bananaWeapon; // Refer�ncia ao script BananaWeapon
    public GameObject cascoBananaPrefab; // Refer�ncia ao prefab do CascoBanana que voc� deseja instanciar.

    void Update()
    {
        // Verifica se a tecla "K" foi pressionada e se o jogador tem pelo menos uma banana.
        if (Input.GetKeyDown(KeyCode.K) && bananaWeapon.bananasColetadas > 0)
        {
            // Reduz a contagem de bananas em 1.
            bananaWeapon.bananasColetadas--;

            // Atualiza o objeto de texto com a nova contagem de bananas.
            bananaWeapon.bananaScore.text = "= " + bananaWeapon.bananasColetadas.ToString();

            // Instancia o prefab do CascoBanana na posi��o atual deste objeto.
            Instantiate(cascoBananaPrefab, transform.position, Quaternion.identity);
        }
    }
}
