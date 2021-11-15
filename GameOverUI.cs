using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public Text Highscore;
    public Text Level;
    bool Updatescore;
    private void Update()
    {
        if (GameController.GameOver == true) {
            Updatescore = true;
            if (Updatescore == true) {
                UpdateScore();
                Updatescore = false;
            }
          
        }
    }
    public void UpdateScore()
    {
        //Score.text = GameController.Puntaje.ToString();
        Highscore.text = GameController.BestPuntaje.ToString();
        //Level.text = GameController.oldlevel.ToString();
    }
}
