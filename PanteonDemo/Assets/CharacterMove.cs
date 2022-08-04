using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CharacterMove : MonoBehaviour
{


    [Header("Movement")]
    [SerializeField] public float dragMultiplier = 2f;
    [SerializeField] private Vector2 bounds;

    private float mouseStartPos;
    private float mouseCurrentPos;
    private float mouseStartPos2;
    private float mouseCurrentPos2;
    private float playerCurrentPos;
    public float playerSpeed = 5f;
    public Rigidbody rb;

    [SerializeField] float moveSpeed = 5f;

    private Vector3 pointA;
    private Vector3 pointB;
    private bool touchStart = false;
    private void Start()
    {
        playerCurrentPos = transform.localPosition.x;
        mouseStartPos = Input.mousePosition.x;
        mouseStartPos /= Screen.width;
        mouseStartPos2 = Input.mousePosition.y;
        mouseStartPos2 /= Screen.width;
        rb = GetComponent<Rigidbody>();
    }

    // void Update() 
    // {


    //     // transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime);
    // }
    private void FixedUpdate()
    {
        //   CheckInputs();
        // RotateAndMove();
        HandLeMovement();
        rb.velocity = Vector3.forward * playerSpeed * Time.deltaTime * 50;
    }

    private void Update()
    {


    }

    void HandLeMovement()
    {
        //gameObject.transform.DORotate(new Vector3(0f, 0f, 0f), 0.2f);

        if (Input.GetMouseButtonDown(0))
        {
          
          /*  mouseStartPos = Input.mousePosition.x;
            mouseStartPos /= Screen.width;
            mouseStartPos2 = Input.mousePosition.y;
            mouseStartPos2 /= Screen.width;*/


        }
        if (Input.GetMouseButton(0))
        { 
            playerCurrentPos = transform.localPosition.x;
            mouseCurrentPos = Input.mousePosition.x;
            mouseCurrentPos /= Screen.width;
            mouseCurrentPos2 = Input.mousePosition.y;
            mouseCurrentPos2 /= Screen.width;


            float targetPos = playerCurrentPos + (mouseCurrentPos - mouseStartPos) * dragMultiplier;

            targetPos = Mathf.Clamp(targetPos, bounds.x, bounds.y);

            /*  float targetPos2 = Mathf.Clamp(targetPos * 10, -25, 25);
               transform.rotation = Quaternion.Euler(0, targetPos2, 0);
               targetPos2 = 0;*/
            /*       Vector3 direction=new Vector3( 0,mouseCurrentPos - mouseStartPos, mouseCurrentPos2 - mouseStartPos2);


                   Vector3 direction2 = Vector3.ClampMagnitude(direction, 1f); 
                   direction2.z = Mathf.Abs(direction2.z);
                   direction2.z = Mathf.Clamp(direction2.z, 0.3f, 0.5f);

                   if (direction2.y < -0.3f)
                   {
                       direction2.y =- 0.3f;
                   }
                   else if (direction2.y > 0.3f)
                   {
                       direction2.y = 0.3f;          
                   }
                transform.rotation = Quaternion.Euler(direction2*100);
                direction2 = Vector3.zero;*/
            // gameObject.transform.DORotate(direction2*100, 0.08f);









            /*  if (targetPos - transform.localPosition.x == 0.0)

                {
                    gameObject.transform.DORotate(new Vector3(0f, 0f, 0f), 0.1f);
                }*/
            /*   else
               if (targetPos> transform.localPosition.x)
               {

                 gameObject.transform.DORotate(new Vector3(0f, 10f, 0f), 0f);
               }
               else if(targetPos<transform.localPosition.x)
               {
                   gameObject.transform.DORotate(new Vector3(0f, -10f, 0f),0f);
               }*/
            /*  if (targetPos - transform.localPosition.x == 0.0)
              {
                  gameObject.transform.DORotate(new Vector3(0f, 0, 0f), 0.1f);
              }
              else gameObject.transform.DORotate(new Vector3(0f, targetPos * 10, 0f), 0f);*/

            transform.localPosition = new Vector3(targetPos, transform.localPosition.y, transform.localPosition.z);

        }
        if (Input.GetMouseButtonUp(0))
        {

         /*   transform.rotation = Quaternion.Euler(0, 0, 0);
            gameObject.transform.DORotate(new Vector3(0f, 0f, 0f), 0.12f);
            gameObject.transform.DORotate(new Vector3(0f, 0f, 0f), 0.12f);
            transform.rotation = Quaternion.Euler(0, 0, 0);*/
        }

    }
    private void CheckInputs()
    {
        if (Input.GetMouseButtonDown(0))
        {

            pointA = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.y);
            touchStart = true;
            pointA /= Screen.width;
        }

        if (Input.GetMouseButton(0))
        {
            pointB = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.y);
            pointB /= Screen.width;
        }
        else
        {
            touchStart = false;
        }
    }

    private void RotateAndMove()
    {
        if (Input.GetMouseButtonDown(0))
        {

            pointA = new Vector3(gameObject.transform.position.x, 0, 0);

            pointA /= Screen.width;
        }

        if (Input.GetMouseButton(0))
        {
            pointB = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.y);
            pointB /= Screen.width;

            Vector3 offset = pointB - pointA;
            Vector3 direction = Vector3.ClampMagnitude(offset, 1.0f);


            direction.z = Mathf.Clamp(direction.z, 0, 1f);
            transform.rotation = Quaternion.LookRotation(direction);
            transform.Translate(direction * 10 * Time.deltaTime, Space.World);


        }
        else
        {
            if (gameObject.transform.rotation.y != 0f)
            {
                gameObject.transform.DORotate(new Vector3(0f, 0f, 0f), 0.2f);
            }
        }



        float newXPos = Mathf.Clamp(transform.position.x, -3.5f, 3.5f); // clamping the x value to prevent falling, [-9, 9] boundaries
        transform.position = new Vector3(newXPos, transform.position.y, transform.position.z);
    }


}


