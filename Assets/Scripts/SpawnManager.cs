using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;
    public float spawnRange = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", 0, 25.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnRandomAnimal()
    {
        Vector3 spawnPos = new Vector3((Random.Range(-spawnRange, spawnRange)), (Random.Range(-spawnRange, spawnRange)), 0);
        Instantiate(enemy, spawnPos, enemy.transform.rotation);
    }
}
