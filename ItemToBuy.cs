using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;
public class ItemToBuy : MonoBehaviour
{
    public string ThisTag;
    public GameObject NewPlayer;
    public Transform transform_store;
    public static bool Isbought;
    public GameObject CostoImage;
    public int costo;
    public int ShopPlayer;
    public bool Comprado;
    private void Start()
    {

        if (PlayerPrefs.GetInt(ThisTag) == 0)
        {
            Comprado = false;
        }
        else {
            Comprado = true;
        } 
        CostoImage.SetActive(!Comprado);
    }
    public void InstantiatePlayer() {


        if (PlayerPrefs.GetInt("Money") >= costo && PlayerPrefs.GetInt(ThisTag) == 0)
        {

            GameController.Money = PlayerPrefs.GetInt("Money") - costo;
            PlayerPrefs.SetInt("Money", GameController.Money);
            PlayerPrefs.Save();
            PlayerPrefs.SetInt(ThisTag, 1);
            Debug.Log("Mi dinero es " + GameController.Money);
            CostoImage.SetActive(false);
            PlayerPrefs.SetInt("Player", ShopPlayer);
        }

        else if (PlayerPrefs.GetInt(ThisTag) == 1) {
            PlayerPrefs.SetInt("Player", ShopPlayer);
            Debug.Log("Comprado");
        }
                else {
            Debug.Log("No tienes dinero");
        }


        if (transform_store.GetChild(0).tag == ThisTag)
        {
            return;
        }
        else {
            if (transform_store.childCount >= 1)
            {
                Destroy(transform_store.GetChild(0).gameObject);
                Instantiate(NewPlayer, transform_store);
                
            }
        }
        
    }
  
}
