using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class StoreSystem : MonoBehaviour
{
    
    public Transform transform_store;
    public GameObject [] NewPlayer;

    public Text MyMoney;
    // Start is called before the first frame update
    void Start()
    {

        Destroy(transform_store.GetChild(0).gameObject);
        Instantiate(NewPlayer[PlayerPrefs.GetInt("Player")], transform_store);
        MyMoney.text = PlayerPrefs.GetInt("Money").ToString();
        Admob.Instance.RequestBanner();

    }

    // Update is called once per frame
    void Update()
    {
        MyMoney.text = PlayerPrefs.GetInt("Money").ToString();
    }
}
