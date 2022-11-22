using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject prefabEnemy;
    public Camera mainCam;
    private float spawnTimer;
    private float spawnRate = 3.0f;
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
            spawn.x+=5;
            spawn.y = y;
            Instantiate(prefabEnemy, spawn,transform.rotation);
            spawnTimer = Time.time + spawnRate;
        }
    }
}
