using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBanana : MonoBehaviour
{
    public BananaWeapon bananaWeapon; // Referência ao script BananaWeapon
    public GameObject cascoBananaPrefab; // Referência ao prefab do CascoBanana que você deseja instanciar.

    void Update()
    {
        // Verifica se a tecla "K" foi pressionada e se o jogador tem pelo menos uma banana.
        if (Input.GetKeyDown(KeyCode.K) && bananaWeapon.bananasColetadas > 0)
        {
            // Reduz a contagem de bananas em 1.
            bananaWeapon.bananasColetadas--;

            // Atualiza o objeto de texto com a nova contagem de bananas.
            bananaWeapon.bananaScore.text = "= " + bananaWeapon.bananasColetadas.ToString();

            // Instancia o prefab do CascoBanana na posição atual deste objeto.
            Instantiate(cascoBananaPrefab, transform.position, Quaternion.identity);
        }
    }
}
