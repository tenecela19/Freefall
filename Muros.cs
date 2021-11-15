using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muros : MonoBehaviour
{
    // Start is called before the first frame update
    public static Color colornuevo;
    
    private void Start()
    {
            gameObject.GetComponent<Renderer>().material.color = colornuevo;
            gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", colornuevo);
        
    }
}
