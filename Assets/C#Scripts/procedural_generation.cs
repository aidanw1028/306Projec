using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class procedural_generation : MonoBehaviour
{
    public GameObject Obstacle;
    
    public float maxY;
    public float minY;

    public float TimeBetweenSpawn;
    private float SpawnTime;

    private float camSpeed = .50f;

    void Spawn()
    {
        //spawn enemies randomly
        Debug.Log(transform.position.x);
        float X = Random.Range((int)(transform.position.x)+10, (transform.position.x) + 30);
        float Y = Random.Range(minY, maxY);

        Instantiate(Obstacle, new Vector3(X, Y, 0), transform.rotation);
         
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position += Vector3.right * Time.deltaTime * camSpeed;

        if (Time.time > SpawnTime)
        {
            Spawn();
            SpawnTime = Time.time + TimeBetweenSpawn;
        }
    }
}
