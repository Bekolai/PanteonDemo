using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject girlPrefab, boy;
    public List<Vector3> spawnPos;
    // Start is called before the first frame update
    void Awake()
    {
        SpawnPlayer();
        SpawnAI();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnPlayer()
    {
        int RandomNum = Random.Range(0, spawnPos.Count);
        boy.transform.position = (spawnPos[RandomNum]);
        spawnPos.RemoveAt(RandomNum);
    }
    void SpawnAI()
    {
        int x = spawnPos.Count;
        for (int i = 0; i < x; i++)
        {
          int RandomNum = Random.Range(0, spawnPos.Count);
        Instantiate(girlPrefab, (spawnPos[RandomNum]), Quaternion.identity);
        spawnPos.RemoveAt(RandomNum);
        }

       
    }
}
