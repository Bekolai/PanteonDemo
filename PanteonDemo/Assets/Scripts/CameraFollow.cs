using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;


    // Update is called once per frame
    void LateUpdate()
    {
      
          transform.position = new Vector3(0, 0, target.position.z) + offset;
     
        
       
    }
    private void Start()
    {
     
    }
}
