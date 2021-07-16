using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random_spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;

    private int rand;
    private int randposition;

    public float startTimeSpawn;
    private float timeSpawn;

    // Start is called before the first frame update
    void Start()
    {
        timeSpawn = startTimeSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeSpawn <= 0)
        {
            rand = Random.Range(0, enemyPrefabs.Length);
            randposition = Random.Range(0, spawnPoints.Length);
            Instantiate(enemyPrefabs[rand], spawnPoints[randposition].transform.position, Quaternion.identity);
            timeSpawn = startTimeSpawn;
        }
        else
        {
            timeSpawn -= Time.deltaTime;
        }
    }
}
