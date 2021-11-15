using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelPanel : MonoBehaviour
{
    public Text LevelCompletedText;
    public Text NextLevelText;
    public Text HighScoreCompletedText;
    public Text ScoreCompletedText;
    public GameObject objsectsInScene;
    public GameObject ParticleSytemMoney;
    public Text MoneyText;
    private static int TimeToShowIntertetial2;

    // Start is called before the first frame update
    void Start()
    {

        LevelCompletedText.text = "LEVEL " + GameController.oldlevel;
        NextLevelText.text = "Next level " + GameController.level;
        HighScoreCompletedText.text = "Highscore: " + GameController.BestPuntaje.ToString();
        ScoreCompletedText.text = GameController.Puntaje.ToString();
        objsectsInScene.SetActive(false);
        FindObjectOfType<SoundManager>().Play("Aplauso");
        Instantiate(ParticleSytemMoney);
        MoneyText.text = PlayerPrefs.GetInt("Money").ToString();

    }
    private void Update()
    {
    }
    public void ChangeScene()
    {
        TimeToShowIntertetial2++;
        if (TimeToShowIntertetial2 == 3)
        {
            Admob.Instance.RequestInterstitial();
            Admob.Instance.ShowInterstitialAd();
            TimeToShowIntertetial2 = 0;
        }
        PlayerPrefs.SetInt("Beta2", 0);
        SceneManager.LoadScene(0);

    }

}
