using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float health = 500.0f;
    [SerializeField] private float moveSpeed = 10.0f;
    [SerializeField] private float damage = 50.0f;

    // projectile vars
    [SerializeField] private Projectile projectile;
    [SerializeField] private float fireRate = 5.0f;
    [SerializeField] private float fireTime;
    Vector2 playerPos;
    // Start is called before the first frame update
    void Start()
    {
        playerPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Shoot();
    }

    void MovePlayer() {
        if(Input.GetKey(KeyCode.W)) {
            transform.position += Vector3.up *moveSpeed*Time.deltaTime;
            }
        if(Input.GetKey(KeyCode.S)) {
            transform.position += Vector3.down * moveSpeed*Time.deltaTime;
            }
        if(Input.GetKey(KeyCode.A)) {
            transform.position += Vector3.left * moveSpeed*Time.deltaTime;
            }
        if(Input.GetKey(KeyCode.D)) {
            transform.position += Vector3.right * moveSpeed*Time.deltaTime;
            }
    }
    /**
    * Player takes damage if shot
    */
    public void TakeDamage(float damage) {
        health -=damage;
        if(health<=0) {
            Destroy(this.gameObject);
        }

    }


    private void Shoot() {
        if (Time.time >= fireTime) {
            Projectile a = Instantiate(projectile, transform.position, transform.rotation);

            // Sets the firedelay for player
            fireTime = Time.time + fireRate;
        }
    }
}
