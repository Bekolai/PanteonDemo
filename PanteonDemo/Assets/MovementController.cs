using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovementController : MonoBehaviour
{


    [Header("Movement")]
    [SerializeField] public float playerSpeed = 10f;
    [SerializeField] public float xSpeed = 10f;
    [SerializeField] public float xClamp = 3.5f;



    float _playerSpeed;
    float _xSpeed,direction;
    public Rigidbody rb;

    public Camera mainCamera;
    private float _distanceToScreen;
    private Vector3 _mousePos;
    private void Start()
    {


        StartMovement();
        rb = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {

         Movement();
     rb.velocity = Vector3.forward * playerSpeed * Time.deltaTime;

      
         
          
     
   
   
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {

            var position = Input.mousePosition;

            _distanceToScreen = mainCamera.WorldToScreenPoint(gameObject.transform.position).z;
            _mousePos = mainCamera.ScreenToWorldPoint(new Vector3(position.x, position.y, _distanceToScreen));
            direction = _xSpeed;
            direction = _mousePos.x > transform.position.x ? direction : -direction;


        }
    }


    void Movement()
    {
       

          if (Math.Abs(_mousePos.x - transform.position.x) > 0.25f )
            {
             transform.Translate(Time.deltaTime * direction, 0, 0);
             
            } 
     
            var pos = transform.position; // TO CHECK IF CHARACTER IS IN X AXIS BORDER 
            pos.x = Mathf.Clamp(transform.position.x, -xClamp, xClamp);//
            transform.position = pos;//



    }
    public void StopMovement()
    {
        _xSpeed = 0f;
        _playerSpeed = 0f;
    }
    public void StartMovement()
    {
        _xSpeed = xSpeed;
        _playerSpeed = playerSpeed;
    }


  




}
