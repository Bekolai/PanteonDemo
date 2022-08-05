using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject girlPrefab, boy;
    public List<Vector3> spawnPos;
    public List<GameObject> aiChars;
    public TMP_Text countdownText, rankingText;
    int playerRank, finishedCount;

    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
         SpawnPlayer();
         SpawnAI();
    }

    private void Start()
    {
        StartCoroutine(StartGame());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        checkRanking();
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
        GameObject aiChar=Instantiate(girlPrefab, (spawnPos[RandomNum]), Quaternion.identity);
            aiChars.Add(aiChar);
        spawnPos.RemoveAt(RandomNum);
        }

       
    }
    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(1f);
        countdownText.text = "2";
        yield return new WaitForSeconds(1f);
        countdownText.text = "1";
        yield return new WaitForSeconds(1f);
        countdownText.text = "GO!";
        boy.GetComponent<PlayerController>().StartGame();
        foreach (GameObject o in aiChars)
        {
            o.GetComponent<AIcontroller>().StartGame();
        }
        yield return new WaitForSeconds(0.5f);
        countdownText.gameObject.SetActive(false);
    }
    void checkRanking()
    {
        playerRank = 1;
        Vector3 playerLoc = boy.transform.position;
        for(int i=0;i<aiChars.Count;i++)
        {
            if (aiChars[i].transform.position.z>=playerLoc.z) //check if ai is further than player
            {
                playerRank++;
            }
        }
        playerRank += finishedCount; //add finished characters to ranking.
        rankingText.text = playerRank.ToString() + "/11";

    }
    public void AIfinished(GameObject gameObject)
    {
        aiChars.Remove(gameObject);
        finishedCount++;
    }
}
