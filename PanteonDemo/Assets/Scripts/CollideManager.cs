using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollideManager : MonoBehaviour
{
    Transform spawner;
    public static CollideManager Instance { get; private set; }
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
        spawner = GameObject.Find("Spawner").GetComponent<Transform>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HandleRespawn(GameObject gameObj)
    {
        float randomNumber = Random.Range(-1f, 1f);
        float randomNumber2 = Random.Range(0, 1);
        gameObj.transform.DOMove(spawner.transform.position+new Vector3(randomNumber,0,0), 1f);
        gameObj.transform.GetChild(3).GetComponent<ParticleSystem>().Play();
    }

}
