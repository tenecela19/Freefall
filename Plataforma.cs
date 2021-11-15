using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    public Transform[] target;
    public float speed = 6.0f;

    int curPos = 0;
    int nextPost = 1;


    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, target[nextPost].position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target[nextPost].position )<= 0) {
            curPos = nextPost;
            nextPost++;

            if (nextPost > target.Length - 1) {
                nextPost = 0;
            }
        }
    }
}
