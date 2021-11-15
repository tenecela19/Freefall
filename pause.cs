using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{

    bool touch;
    public GameObject PausePanel;
    public GameObject buttoms;
    int TimeToShowIntertetial;
    public void PAUSE()
    {
        touch = !touch;
        PausePanel.SetActive(touch);
        if (touch == true) { buttoms.SetActive(false); Time.timeScale = 0;
           Admob.Instance.RequestBanner(); 
        }
        else {
            if(BarLevel.IsStarting == true)
            {
                buttoms.SetActive(false);

            }
            else
            {
                buttoms.SetActive(true);
            }
            Time.timeScale = 1; 
            Admob.Instance.bannerView.Destroy(); 
        }

        }
    public void Restart() {
        Time.timeScale = 1;
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        GameController.Instance.Restart();     
        PausePanel.SetActive(false);
        buttoms.SetActive(true);
        if (TimeToShowIntertetial == 4)
        {
           Admob.Instance.RequestInterstitial();
            Admob.Instance.ShowInterstitialAd();
            TimeToShowIntertetial = 0;
        }

    }
}
