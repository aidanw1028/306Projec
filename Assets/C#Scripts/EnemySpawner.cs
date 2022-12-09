using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject lightEnemy;
    public GameObject heavyEnemy;
    public Camera mainCam;
    private float spawnTimer;
    private float spawnRate = 4.0f;
    private float heavyEnemySpawnTimer = 30.0f;
    private float heavyEnemySpawnRate = 30.0f;
    private float spawnIncreaseTime = 30.0f;
    private float increaseTimer = 20;
    private float increaseHeavyTimer = 45.0f;

    // Start is called before the first frame update
    void Start()
    {
       mainCam = Camera.main; 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = mainCam.transform.position;

        SpawnEnemy();


    }
    private void SpawnEnemy() {
        if(Time.time > spawnTimer) {
            Vector3 spawn = transform.position;
            int y = Random.Range(-1,-4);
            spawn.z = 0;
            spawn.x+=10;
            spawn.y = y;
            Instantiate(lightEnemy, spawn,transform.rotation);
            if (Time.time > heavyEnemySpawnTimer) {
                spawn.y -= 1;
                Instantiate(heavyEnemy, spawn, transform.rotation);
                heavyEnemySpawnTimer = Time.time + heavyEnemySpawnRate;
            }
            spawnTimer = Time.time + spawnRate;
        }
        if (Time.time > increaseTimer)
        {
           
            if (spawnRate <= 1.00f) {
                spawnRate = 1.00f;
                buffEnemy();
        
            }
            else {
                buffEnemy();
                spawnRate -= 0.575f;

            }
            increaseTimer = Time.time + spawnIncreaseTime;
        }
        if (Time.time > increaseHeavyTimer) {
            if (heavyEnemySpawnRate <= 5.0f) {
                heavyEnemySpawnRate = 5.0f;
                buffHeavyEnemy();

            }
            else {
                buffHeavyEnemy();
                heavyEnemySpawnRate -= 5.0f;

            }
            increaseHeavyTimer = Time.time + increaseHeavyTimer;
        }
    }

    void buffEnemy() {
        lightEnemy.GetComponent<Enemy>().increaseStats();
    }

    void buffHeavyEnemy() {
        heavyEnemy.GetComponent<HeavyEnemy>().increaseStats();
    }
}
