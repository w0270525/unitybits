using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

    
    public GameObject enemy;                // The enemy prefab to be spawned.
    public float spawnTime = 3f;            // How long between each spawn.
    public GameObject[] SpawnPoints;         // An array of the spawn points this enemy can spawn from.
    protected int enemyCount;
    protected int wave;

    void Start()
    {
        enemyCount = 1;
        wave = 1;

        
        //gets the locations for the enemies to spawn.
        SpawnPoints = GameObject.FindGameObjectsWithTag("EnemySpawn");

        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }


    void Spawn()
    {
        // If the player has no health left...
        //if (playerHealth.currentHealth <= 0)
        //{
        //    // ... exit the function.
        //    return;
        //}
        enemyCount = (int) Mathf.Log(wave, 2f);

        for (int x = 0; x < enemyCount; x++)
        {


            // Find a random index between zero and one less than the number of spawn points.
            int spawnPointIndex = Random.Range(0, SpawnPoints.Length);

            // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
            Instantiate(enemy, SpawnPoints[spawnPointIndex].transform.position, Quaternion.identity);
            enemy.SetActive(true);

        }

        //progress to next wave
        wave++;
    }
}
