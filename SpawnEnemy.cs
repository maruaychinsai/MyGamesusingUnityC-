using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    public float timer = 0.0f;

   

// Start is called before the first frame update
    void Start()
    {
     timer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - timer > 10)
        {
            SpawnCube();
            timer = Time.time;
        }
    }
    void SpawnCube()
    {
        int randEnemy = Random.Range(0, enemyPrefabs.Length);
    int randSpawPoint = Random.Range(0, spawnPoints.Length);

      Instantiate(enemyPrefabs[randEnemy], spawnPoints[randSpawPoint].position, transform.rotation);
    }

}
