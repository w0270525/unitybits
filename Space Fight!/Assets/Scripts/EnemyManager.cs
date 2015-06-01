using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

    
    public GameObject enemy;                // The enemy prefab to be spawned.
    public GameObject enemy2;
    public GameObject enemy3;
    private int numberOfGameObjects = 3;

    public float spawnTime = 3f;            // How long between each spawn.
    public GameObject[] SpawnPoints;         // An array of the spawn points this enemy can spawn from.
    protected int enemyCount;
    protected int wave;
    public GameObject playerObj;

    void Start()
    {
        enemyCount = 1;
        wave = 1;

        playerObj = GameObject.FindGameObjectWithTag("Player");
        //gets the locations for the enemies to spawn.
        SpawnPoints = GameObject.FindGameObjectsWithTag("EnemySpawn");

        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
       
            InvokeRepeating("Spawn", spawnTime, spawnTime); 
       
    }


    void Spawn()
    {
        //ensure the player is active.
        if (playerObj.activeInHierarchy)
        {
            // If the player has no health left...
            //if (playerHealth.currentHealth <= 0)
            //{
            //    // ... exit the function.
            //    return;
            //}
            enemyCount = (int)Mathf.Log(wave, 2f);

            for (int x = 0; x < enemyCount; x++)
            {


                // Find a random index between zero and one less than the number of spawn points.
                int spawnPointIndex = Random.Range(0, SpawnPoints.Length);

                // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
                PickEnemy(spawnPointIndex);

            }

            //progress to next wave
            wave++; 
        }
    }

    private void PickEnemy(int spawnPointIndex)
    {
        int spawn = Random.Range(0, numberOfGameObjects);

        switch (spawn)
        {
            case 0:
            {
                Instantiate(enemy, SpawnPoints[spawnPointIndex].transform.position, Quaternion.identity);
                enemy.SetActive(true);
                break;
            }
            case 1:
            {
                Instantiate(enemy2, SpawnPoints[spawnPointIndex].transform.position, Quaternion.identity);
                enemy2.SetActive(true);
                break; 
            }
            case 2:
            {
                Instantiate(enemy3, SpawnPoints[spawnPointIndex].transform.position, Quaternion.identity);
                enemy3.SetActive(true);
                break;
            }
                
        }

    }
}
