using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{

    public void Start()
    {
        
        Bloques.colornuevo = Random.ColorHSV();
        Muros.colornuevo = Random.ColorHSV(); 
        SceneManager.LoadSceneAsync(1);
    }




}