using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToPlay : MonoBehaviour
{
    public static bool inTouch = true;

    private void Awake()
    {
        gameObject.SetActive(inTouch);
    }
    public void OnTouch()
    {
        inTouch = false;
        gameObject.SetActive(inTouch);
    }
}
