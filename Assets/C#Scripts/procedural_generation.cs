using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class procedural_generation : MonoBehaviour
{
    public GameObject Obstacle;
    public Sprite[] obstacleSprites;
    
    public float maxY;
    public float minY;

    public float TimeBetweenSpawn;
    private float SpawnTime;

    private float camSpeed = .50f;

    void Spawn()
    {
        //spawn enemies randomly
        int arrayIdx = Random.Range(0,obstacleSprites.Length);
        Sprite obstacleSprite = obstacleSprites[arrayIdx];
  

        float X = Random.Range((int)(transform.position.x)+10, (transform.position.x) + 30);
        float Y = Random.Range(minY, maxY);

        GameObject newObstacle = Instantiate(Obstacle, new Vector3(X, Y, 0), transform.rotation);
        newObstacle.GetComponent<SpriteRenderer>().sprite = obstacleSprite;
         
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
