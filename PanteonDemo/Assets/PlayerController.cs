using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    MovementController movementController;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
       movementController= GetComponent<MovementController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Collider"))
        {
            movementController.StopMovement();
            CollideManager.Instance.HandleRespawn(gameObject);
        }
    }
}