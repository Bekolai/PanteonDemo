using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIcontroller : MonoBehaviour
{
    public GameObject finish;
    NavMeshAgent navMeshAgent;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(finish.transform.position);


    }

    // Update is called once per frame
    void Update()
    {
      //  navMeshAgent.velocity=(Vector3.forward * 100 * Time.deltaTime);
       // Vector3.forward* _playerSpeed *Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collider"))
        {
          //  movementController.StopMovement();
            CollideManager.Instance.HandleRespawn(gameObject);
        }

    }
}
