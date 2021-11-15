using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Settings : MonoBehaviour
{
    public bool touch;
    public void OpenSettings() {
        touch = !touch;
        gameObject.transform.GetChild(0).gameObject.SetActive(touch);
       }
    
}
