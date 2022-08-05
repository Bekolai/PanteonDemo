using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class AIcontroller : MonoBehaviour
{
     GameObject finish;
    NavMeshAgent navMeshAgent;
    Vector3 velocity;
    public bool collided;
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
        Debug.Log(navMeshAgent.nextPosition);
        if (!collided)

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
            CollideManager.Instance.HandleRespawn(gameObject);
            StartCoroutine(collideReset());
            
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 0.5f);
            Destroy(gameObject, 0.5f);

        }


    }
    IEnumerator collideReset()
    {
      
        yield return new WaitForSeconds(1f); 
        navMeshAgent.nextPosition = transform.position;
        collided = false;
    }
}
