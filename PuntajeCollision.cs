using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PuntajeCollision : MonoBehaviour
{

    public int PuntajeDeBloque;
    GameController controller;
    public GameObject PuntajeParticle;

    public static int Incre;
    private void Start()
    {
        GameObject gamecontrol = GameObject.FindGameObjectWithTag("GameController");
        controller = gamecontrol.GetComponent<GameController>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (gameObject == other.gameObject.CompareTag("Player"))
        {
            if (GameController.GameOver == false)
            {
                int score = (PuntajeDeBloque + GameController.oldlevel) * GameController.CanDoSuper;
                controller.AddScore(score);
                GameObject puntaje = Instantiate(PuntajeParticle,GameObject.FindGameObjectWithTag("Canvas").transform);                
                puntaje.GetComponent<TextMeshProUGUI>().text = "+ " + (score).ToString();
                puntaje.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = puntaje.GetComponent<TextMeshProUGUI>().text;
                Incre += 2;
                puntaje.GetComponent<TextMeshProUGUI>().color = Bloques.colornuevo;
                FindObjectOfType<SoundManager>().RandomPitch("Puntos");
                FindObjectOfType<SoundManager>().Play("Puntos");
               


            }
        }
    }
}
