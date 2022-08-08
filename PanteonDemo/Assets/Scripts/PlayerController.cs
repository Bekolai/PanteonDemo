using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PlayerController : MonoBehaviour
{
    MovementController movementController;
    Transform checkPoint;
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
            CollideManager.Instance.HandleRespawn(gameObject,checkPoint);
            StartCoroutine(collideReset());
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            movementController.StopMovement();
            GetComponent<Animator>().SetBool("Run", false);
            transform.DOMove(new Vector3(0, transform.position.y, transform.position.z + 2),1f);
            GameManager.Instance.PlayerFinish(gameObject);
        }

    }
    IEnumerator collideReset()
    {
        GetComponent<Animator>().SetBool("Run", false);
        yield return new WaitForSeconds(1f);
        movementController.StartMovement();
        GetComponent<Animator>().SetBool("Run", true);


    }
    public void StartGame()
    {
        GetComponent<Animator>().SetBool("Run", true);
        movementController.StartMovement();
    }
    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.CompareTag("Checkpoint"))
        {
            checkPoint = other.gameObject.transform.parent;
        }
     /*   if (other.gameObject.CompareTag("Knockback"))
        {
            Vector3 moveDirectionPush = gameObject.transform.position - other.transform.position;
            moveDirectionPush.y = 0f;
            GetComponent<Rigidbody>().AddForce(moveDirectionPush.normalized * 25f,ForceMode.Impulse);
        }*/ //Rotator stick test
    }
}
