using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderMoveX : MonoBehaviour
{
    public float xClamp;
    public float speed = 2.0f;


    void Start()
    {

    }

    void FixedUpdate()
    {
        Vector3 v = transform.position;
        if (Mathf.Abs(v.x) != xClamp) // if x in border move sideways
        {
         v.x +=(Time.deltaTime * speed);   
         v.x = Mathf.Clamp(v.x, -xClamp, xClamp); 
        transform.position = v;
        }
        else
        {
            speed *= -1; //change movement rotation
            v.x += (Time.deltaTime * speed);
            transform.position = v;
        }
       
    }
}