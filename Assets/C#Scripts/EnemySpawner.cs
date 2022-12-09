using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject prefabEnemy;
    public Camera mainCam;
    private float spawnTimer;
    private float spawnRate = 4.0f;
    private float spawnIncreaseTime = 30.0f;
    private float increaseTimer = 25;
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
            Instantiate(prefabEnemy, spawn,transform.rotation);
            spawnTimer = Time.time + spawnRate;
        }
        if (Time.time > increaseTimer)
        {
            Debug.Log("Lower enemy spawn rate");
            if (spawnRate <= 1.25f) {
                spawnRate = 1.25f;
            }
            else {
                spawnRate -= 0.40f;
            }
            increaseTimer = Time.time + spawnIncreaseTime;
        }
    }

    void buffEnemy() {
        prefabEnemy.GetComponent<Enemy>().increaseStats();
    }
}
