using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAdReward : MonoBehaviour
{
    public Image AdButtonIm;
    public float speed;
    public GameObject ButtonAd;
    public float TimeToDissapair;
    public Text ContinueText;
    public static int opportunnityToContinue = 3;
    void Start() {

        ContinueText.text = "Continue? " + opportunnityToContinue.ToString();
    }
    public void RewardedVideo()
    {
        Admob.Instance.UserChoseToWatchAd();
    }

      
}

