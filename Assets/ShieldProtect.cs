using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldProtect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().isShieldOn = true;
            Destroy(this.gameObject);
        }
    }
}

