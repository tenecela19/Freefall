using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByCollision : MonoBehaviour
{
     public int ObjectNumber;

        void OnTriggerEnter(Collider collision)
    {
        if (gameObject == collision.gameObject.CompareTag("Meta") || gameObject == collision.gameObject.CompareTag("Suelo"))
        {

            gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (gameObject == other.gameObject.CompareTag("Bloque") || gameObject == other.gameObject.CompareTag("BloqueArea")) {
            if (other.gameObject.transform.position.y > transform.position.y)
            {
                gameObject.SetActive(false);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject == collision.gameObject.CompareTag("Bloque") || gameObject == collision.gameObject.CompareTag("BloqueArea"))
        {
            if (collision.gameObject.transform.position.y > transform.position.y)
            {
                gameObject.SetActive(false);
            }
        }
    }
    
}
