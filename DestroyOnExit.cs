using UnityEngine;
using System.Collections;

public class DestroyOnExit : MonoBehaviour
{

    private void OnTriggerExit(Collider other)
    {
        if (gameObject == other.gameObject.CompareTag("Player")) {
            GameController.GameOver = true;
            other.gameObject.SetActive(false);
        }
    }
}
