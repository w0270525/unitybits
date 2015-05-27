using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

    public float startWait = 3f;
    public GameObject[] SpawnPoints;

    public int Score = 0;



    // Use this for initialization
    void Start ()
    {
        SpawnPoints = GameObject.FindGameObjectsWithTag("EnemySpawn");

        StartCoroutine(SpawnWaves());
    }
    
    // Update is called once per frame
    void Update () {
    
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            int rndIndex = Random.Range(0, SpawnPoints.Length);
        }
    }


}

