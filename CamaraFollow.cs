using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    private Vector3 velocity;
    public Camera cam;
    public float SpeedCamFollow;
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        cam.backgroundColor = Muros.colornuevo;
}
    private void FixedUpdate()
    {
        if (target == null && GameController.GameOver == false )
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        if (target != null) {
            Vector3 desiderdPosition = target.position + offset;
            Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, desiderdPosition, ref velocity, smoothSpeed);
            transform.position = smoothPosition;
        }
        if (GameController.GameOver == true) {
            offset.z = -1;
        }
        if (BarLevel.IsStarting == true && GameController.nexlevel == false) offset.y -= Time.deltaTime * SpeedCamFollow;
        if (GameController.GameOver == true) offset.y = 3;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject == other.gameObject.CompareTag("Comenzar")) {
            offset.z = 0;
        }
    }
}