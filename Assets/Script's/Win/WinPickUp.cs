using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPickUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<WinHandler>().HandleWin();
            Destroy(gameObject);
        }
    }
}
