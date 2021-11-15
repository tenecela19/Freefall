using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;
public class Player_Controller : MonoBehaviour
{
    Vector2 touchDeltaPosition;
    public const int NUMSUPER = 5;
    public Animator anim;
    public GameObject Trail;
    public GameObject particulas;
    public Material SuperPunto;
    public GameObject particulasSuper;
    public GameObject ColorMaterial;
    public string AnimName;
    public static bool newlevel;
    SerializationSaving controller;
    public bool PlayOnPc;
    public static int TimeToShowIntertetial2 { get; private set; }

    private void Start()
    {
        controller = GameObject.FindGameObjectWithTag("SavingController").GetComponent<SerializationSaving>();
        if (GameController.CanDoSuper >= NUMSUPER)
        {
            particulas.SetActive(false);
            ColorMaterial.GetComponent<Renderer>().material = SuperPunto;
            Trail.GetComponent<Renderer>().material = SuperPunto;
            GameController.Instance.SUPERPLAYER.SetActive(true);
           
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        //BLOQUES DE 3 Y 4 NO BORRAR
        if (gameObject == collision.gameObject.CompareTag("Bloque"))
        {
            GameController.GameOver = true;
           Destroy(gameObject);
            FindObjectOfType<SoundManager>().Play("Muerte");
            if (GameController.TimeToShowIntertetial == 3)
            {
                Admob.Instance.ShowInterstitialAd();
                GameController.TimeToShowIntertetial = 0;
            }
            Admob.Instance.RequestBanner();

        }
        if (gameObject == collision.gameObject.CompareTag("Meta") && GameController.GameOver == false)
        {

            TimeToShowIntertetial2++;
            if (TimeToShowIntertetial2 == 4)
            {
                Admob.Instance.ShowInterstitialAd();
                TimeToShowIntertetial2 = 0;
            }
            GameController.nexlevel = true;
            GameController.Money = PlayerPrefs.GetInt("Money");
             PlayerPrefs.SetInt("Money", GameController.Money += 25);

            if (GameController.CanDoSuper < NUMSUPER)
            {
                GameController.CanDoSuper++;
            }
            if (GameController.level % 3 == 0 && GameController.level <= 28)
            {
                GameController.BloquesIncre += 2;
            }
            controller.SaveBySerialization();
            gameObject.SetActive(false);
            Bloques.colornuevo = Random.ColorHSV();
            Muros.colornuevo = Random.ColorHSV();

        }
        //ANIMACION CUANDO CAE
        if (gameObject == collision.gameObject.CompareTag("Pared"))
        {
            anim.Play(AnimName);
            FindObjectOfType<SoundManager>().Play("PlayerRebota");

        }
    }
    private void FixedUpdate()
    {

        if (TapToPlay.inTouch == false)
        {
            //CONFIGURACION DE CONTROL DE MOUSE
            if (PlayOnPc == true)
            {
                float pointer_x = Input.GetAxis("Mouse X");
                float pointer_y = Input.GetAxis("Mouse Y");
                transform.Translate(pointer_x * 0.5f,
                            pointer_y * 0.5f, 0);

            }
            else
            {
                //CONFIGURACION DE CONTROL DE TOUCH
                if (Input.touchCount == 1)
                {
                    Touch touchZero = Input.GetTouch(0);
                    if (touchZero.phase == TouchPhase.Moved)
                    {
                        touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                        transform.Translate(touchDeltaPosition.x * .008f, touchDeltaPosition.y * .008f, 0);
                    }
                }
            }


        }
    }
    void OnTriggerEnter(Collider other)
    {
        //JUGADOR GANA PARTIDA SE PONE LOS COLORES ALEATORIOS
        if ((gameObject == other.gameObject.CompareTag("Bloque") || (gameObject == other.gameObject.CompareTag("Suelo"))))
        {
           GameController.GameOver = true;
            Destroy(gameObject);
            FindObjectOfType<SoundManager>().Play("Muerte");
            GameController.TimeToShowIntertetial ++; 
            if(GameController.TimeToShowIntertetial == 3)
            {
                Admob.Instance.ShowInterstitialAd();
                GameController.TimeToShowIntertetial = 0;
            }
           Admob.Instance.RequestBanner();
        }
        if(gameObject == other.gameObject.CompareTag("Comenzar"))
        {
            BarLevel.IsStarting = true;

            Trail.SetActive(true);
            if (GameController.CanDoSuper < NUMSUPER) {
                particulas.SetActive(true);
            }
            else particulasSuper.SetActive(true);

        }

    }
}
