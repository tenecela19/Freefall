using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeToGame : MonoBehaviour
{
    public int Scene;
    int TimeToShowIntertetial2;
    // Start is called before the first frame update
    public void ChangeScene() {

        TimeToShowIntertetial2++;
        if (TimeToShowIntertetial2 == 4)
        {
            Admob.Instance.RequestInterstitial();
            Admob.Instance.ShowInterstitialAd();
            TimeToShowIntertetial2 = 0;
        }
        SceneManager.LoadScene(Scene);
        if(Admob.Instance.bannerView != null) Admob.Instance.bannerView.Destroy();

    }
}
