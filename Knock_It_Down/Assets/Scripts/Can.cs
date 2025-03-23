using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Bu sayfayla can'lar yani silindirler vurulduktan sonra diger seviye gitmesini saglayacak
public class Can : MonoBehaviour
{
    public bool hasFallen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Resetter"))
        {
            hasFallen = true;
            GameManager.instance.GroundFallenCheck();
        }
    }
}
