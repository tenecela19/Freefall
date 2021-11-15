using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using TMPro;
public class GameController : MonoBehaviour
{
    public GameObject[] BloquePrefab;
    public Transform Inicio;
    public Transform Final;
    public static int bloquesNum;
    public static int BloquesIncre;
    public static int level = 1;
    public static int oldlevel = 0;
    public GameObject PlayerPrefab;
    public GameObject Muro;
    public List<GameObject> objects = new List<GameObject>();
    public GameObject[] Players;
    public static bool GameOver;
    public static int Puntaje;
    public static int BestPuntaje;
    public static int CanDoSuper = 1;
    public TextMeshProUGUI scoretext;
    public TextMeshProUGUI BestScoreText;
    public BarLevel bar;
    public Text OldLevelText;
    public Text LevelText;
    public GameObject GameOverPanel;
    public GameObject ObjectsInGame;
    public GameObject Menu;
    public Text Completado;
    public GameObject HighScoreOver;
    public static int Money = 10000;
    [HideInInspector]
    public int bloquesInGame;
    SerializationSaving saving;
    public List<int> BloquesLevel = new List<int>();
   public GameObject NEXLEVELPANEL;
   public GameObject SUPERPLAYER;
    public static bool  nexlevel;
    private static GameController _instance;
    public GameObject pause;
    public GameObject botonpause;
    public static int TimeToShowIntertetial = 0;
    [Header("ButtonReawarded")]
    public Image AdButtonIm;
    public float speed;
    public GameObject ButtonAd;
    public Text ContinueText;
    float timer = 4;
    public static GameController Instance { get { return _instance; } }
    // Start is called before the first frame update

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        saving = GameObject.FindGameObjectWithTag("SavingController").GetComponent<SerializationSaving>();
        int IsFirst = PlayerPrefs.GetInt("Beta2");
        if (IsFirst == 0)
        {
            oldlevel = level;
            level++;
            EmpezarNivel();
            saving.SaveBySerialization();
            PlayerPrefs.SetInt("Beta2", 1);
        }
        else {
            saving.LoadBySerialization(); 
        }
        GameOverPanel.SetActive(false);
        NEXLEVELPANEL.SetActive(false);
        ObjectsInGame.SetActive(true);
        pause.SetActive(false);
        LevelText.text = level.ToString();
        OldLevelText.text = oldlevel.ToString();
        nexlevel = false;
        PuntajeCollision.Incre = 0;

        if (Social.localUser.authenticated)
        {
            PlayServices.Instance.AddScoreToLeaderboard();
        }
      
        UpdateScore();
    }
    private void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player") == true) {
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            Instantiate(Players[PlayerPrefs.GetInt("Player",0)]);
        }

    }



    void Update() {
        IsGameOver();
        NexLevel();
    }
    //AQUI SE CREA LOS NIVELES DE MANERA ALEATORIA SI ES HORIZONTAL O VERTICAL AMBOS SE CREAN EL MISMO MOMEMENTO

    public void TiposDeBloques(int BloqueEscoger) {

        switch (BloqueEscoger) {
            case 0:
                if (bloquesNum <= 38)
                {
                    bloquesNum = Random.Range(15,  30);
                }
                else {
                    bloquesNum = Random.Range(20, 40);
                }
                int cantidad = 0;
                while (cantidad < bloquesNum)
                {
                    int num = Random.Range(0, 2);
                    if (num == 1)
                    {
                        Vector3 spawPosition = new Vector3(0, Random.Range(Final.position.y + 1, Inicio.position.y), Random.Range(-4, 5));
                        Instantiate(BloquePrefab[BloqueEscoger], spawPosition, Quaternion.Euler(0, 90, 0), Muro.transform);
                    }
                    else
                    {
                        Vector3 spawPosition = new Vector3(Random.Range(-4, 5), Random.Range(Final.position.y + 1, Inicio.position.y), 0);
                        Instantiate(BloquePrefab[BloqueEscoger], spawPosition, Quaternion.Euler(0, 0, 0), Muro.transform);
                    }
                    cantidad++;

                }
                break;
            case 1:
                int cantidad2 = 0;
                int NumBloque2 = Random.Range(3,5);
                while (cantidad2 < NumBloque2)
                {
                    int num = Random.Range(0, 2);
                    if (num == 1)
                    {
                        Vector3 spawPosition2 = new Vector3(Random.Range(-4, 5), Random.Range(Final.position.y + 1, Inicio.position.y), 0);
                        GameObject objects = Instantiate(BloquePrefab[BloqueEscoger], spawPosition2, Quaternion.Euler(0, 180, 0), Muro.transform);
                    }
                    else
                    {
                        Vector3 spawPosition = new Vector3(Random.Range(-4, 5), Random.Range(Final.position.y + 1, Inicio.position.y), 0);
                        Instantiate(BloquePrefab[BloqueEscoger], spawPosition, Quaternion.Euler(0, 0, 0), Muro.transform);
                    }
                   
                    cantidad2++;
                }
                break;

            case 2:
                int cantidad3 = 0;
                while (cantidad3 < 5)
                {
                    Vector3 spawPosition = new Vector3(0, Random.Range(Final.position.y, Inicio.position.y), 0);
                    Instantiate(BloquePrefab[BloqueEscoger], spawPosition, Quaternion.Euler(0, 0, 0), Muro.transform);

                    cantidad3++;
                }
                break;


           case 3:
                int cantidad3B = 0;
                while (cantidad3B < 5)
                {
                    Vector3 spawPosition2 = new Vector3(0, Random.Range(Final.position.y, Inicio.position.y), 0);
                    Instantiate(BloquePrefab[BloqueEscoger], spawPosition2, Quaternion.Euler(0, 0, 0), Muro.transform);

                    cantidad3B++;
                }
                break;
           case 4:
                int cantidad4 = 0;
                while (cantidad4 < 5)
                {
                    int num = Random.Range(0, 2);
                    if (num == 1)
                    {
                        Vector3 spawPosition = new Vector3(0, Random.Range(Final.position.y, Inicio.position.y), Random.Range(2, 7));
                        Instantiate(BloquePrefab[BloqueEscoger], spawPosition, Quaternion.Euler(0, 0, 0), Muro.transform);
                    }
                    else
                    {
                        Vector3 spawPosition = new Vector3(0, Random.Range(Final.position.y, Inicio.position.y), Random.Range(-2, -7));
                        Instantiate(BloquePrefab[BloqueEscoger], spawPosition, Quaternion.Euler(0, 0, 0), Muro.transform);
                    }
                        cantidad4++;
                }
                break;
            case 5:
                int cantidad5 = 0;
                while (cantidad5 < 10)
                {
                    Vector3 spawPosition = new Vector3(0, Random.Range(Final.position.y, Inicio.position.y), 0);
                    Instantiate(BloquePrefab[BloqueEscoger], spawPosition, Quaternion.Euler(0, 0, 0), Muro.transform);

                    cantidad5++;
                }

                break;
        }

    }
   
    //CUANDO JUGADOR PIERDE SE GUARDA LOS BLOQUES DEL NIVEL

    public void GuardadoDeBloques() {
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Bloque").Length; i++)
        {
            objects.Add(Muro.transform.GetChild(i).gameObject);
            BloquesLevel.Add(Muro.transform.GetChild(i).GetComponent<DestroyByCollision>().ObjectNumber);
        }
        bloquesInGame = GameObject.FindGameObjectsWithTag("Bloque").Length;

    }
    //REINICIAR LA PARTIDA DESDE LOS OBJETOS QUE SE DEJARON
    void NexLevel() {
        if (nexlevel == true) {
            NEXLEVELPANEL.SetActive(true);
            ObjectsInGame.SetActive(false);
            pause.SetActive(false);
        }
    }
    void IsGameOver() {
        if (GameOver == true)
        {
            GameOverPanel.SetActive(true);
            ObjectsInGame.SetActive(false);
            botonpause.SetActive(false);
            int levelpercentage = (int)(bar.imageBar.fillAmount * 100);
            Completado.text = "You have completed " + levelpercentage.ToString() + "%";
            SUPERPLAYER.SetActive(false);
            AdButtonIm.fillAmount = 1;
            if (ButtonAdReward.opportunnityToContinue <= 0)
            {
                ButtonAd.SetActive(false);
            }
            else ButtonAd.SetActive(true);
            StartCoroutine(VideoAdReward());
        }
    }
    public IEnumerator VideoAdReward()
    {
            if(timer > 0)
        {
          
            timer -= Time.deltaTime * 1.5f;
        }
            if(timer <= 0)
        {
            while (AdButtonIm.fillAmount > 0)
            {
                AdButtonIm.fillAmount -= 0.001f;
                yield return null;
            }
            if(AdButtonIm.fillAmount <= 0) ButtonAd.SetActive(false);

        }


    }
    public void Restart() {

        Admob.Instance.bannerView.Destroy();
        SUPERPLAYER.SetActive(false);
        CanDoSuper = 1;
        bar.imageBar.fillAmount = 0.0f;
        BarLevel.IsStarting = false;
        Puntaje = 0;
        UpdateScore();
        Instantiate(Players[PlayerPrefs.GetInt("Player")]);
        TapToPlay.inTouch = true;
        GameOverPanel.SetActive(false);
        ObjectsInGame.SetActive(true);
        botonpause.SetActive(true);
        pause.SetActive(false);
        Menu.SetActive(true);
        GameOver = false;
        gameObject.GetComponent<BarLevel>().nextlevel.LEVELAmount = 0;
        PuntajeCollision.Incre = 0;
        timer = 4;
        ButtonAd.SetActive(true);
    }

    void EmpezarNivel()
    {
        if (Admob.Instance.bannerView != null)
        {
            Admob.Instance.bannerView.Destroy();
        }
        float ProbBloque = Random.value;
        bool NIvelEspecial = false;
        if (level > 5 && ProbBloque <= 0.2)
        {

            if (level > 7 && ProbBloque <= 0.1)
            {
                TiposDeBloques(2);
                TiposDeBloques(3);
                
            }
          NIvelEspecial = true;
            TiposDeBloques(4);
        }
        if (level % 10 == 0 && ProbBloque >= 0.57 && level > 1)
        {
          NIvelEspecial = true;
            TiposDeBloques(5);
        }
        if (NIvelEspecial == false)
        {
            TiposDeBloques(0);
            if (level > 3 && Random.value >= 0.3)
            {
               TiposDeBloques(1);
            }
        }
        GuardadoDeBloques();
        saving.SaveBySerialization();
    }

    public void AddScore(int score) {
        Puntaje += score;
        if (Puntaje > BestPuntaje)
        {
            BestPuntaje = Puntaje;
            HighScoreOver.SetActive(true);
        }
        else {
            HighScoreOver.SetActive(false);
        }
        UpdateScore();
    }

    void UpdateScore() {
        if (Puntaje > 1000000) scoretext.text = (((float)Puntaje / 1000000)).ToString("F2") + "M";
         if (Puntaje > 10000) scoretext.text = (((float)Puntaje / 1000)).ToString("F2") + "K";
          else  scoretext.text = Puntaje.ToString();
        
      
        
        
        if (BestPuntaje > 1000000) BestScoreText.text = "Best: " + ((float)BestPuntaje / 100000).ToString("F2") + " M";
        else BestScoreText.text = "Best: " + BestPuntaje;
    }
    public void ShowLeaderboard()
    {
        if (Social.localUser.authenticated)
        {
            Social.ShowLeaderboardUI();
        }
    }
}
