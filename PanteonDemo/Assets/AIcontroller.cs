using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class AIcontroller : MonoBehaviour
{
    GameObject finish;
     Transform checkPoint;
    NavMeshAgent navMeshAgent;
    Vector3 velocity;
    bool collided,started;
    // Start is called before the first frame update
    void Start()
    {  
        navMeshAgent = GetComponent<NavMeshAgent>();
          navMeshAgent.updatePosition = false;

        finish = GameObject.Find("FinishObj");
        navMeshAgent.SetDestination(finish.transform.position
            +new Vector3(Random.Range(-1f,1f),0,0)); //setting destination with random x axis point

       

    }
    private void Awake()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (!collided &&started)

        {
            transform.position = Vector3.SmoothDamp(transform.position,
            navMeshAgent.nextPosition,
            ref velocity,
            0.1f);   //fixes the jittery navmesh movement
        }
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collider"))
        {
            collided = true;
            CollideManager.Instance.HandleRespawn(gameObject,checkPoint);
            StartCoroutine(collideReset());
            
        }
        if (collision.gameObject.CompareTag("Finish"))
        {   
            GameManager.Instance.AIfinished(gameObject);
            transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 0.5f);
            Destroy(gameObject, 0.5f);
           

        }


    }
 
    IEnumerator collideReset()
    {
        GetComponent<Animator>().SetBool("Run", false);
        yield return new WaitForSeconds(1f);
        GetComponent<Animator>().SetBool("Run", true);
        navMeshAgent.nextPosition = transform.position;
        collided = false;
    }
    public void StartGame()
    {
        GetComponent<Animator>().SetBool("Run", true);
        started = true;
        navMeshAgent.nextPosition = transform.position; //reset navmesh path
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Checkpoint"))
        {
            checkPoint = other.gameObject.transform.parent;
        }
    }
}
