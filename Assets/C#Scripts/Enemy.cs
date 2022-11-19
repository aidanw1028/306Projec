using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float health = 100.0f;
    [SerializeField] private float moveSpeed = 1.0f;
    [SerializeField] private float damage = 25.0f;
    [SerializeField] private float damageRate = 0.2f;
    private float damageTime;

    //projectile vars
    [SerializeField] private EnemyProjectile projectile;
    [SerializeField] private float fireRate = 3.0f;
    [SerializeField] private float fireTime;
    // Start is called before the first frame update
  
    void Update() {
        Shoot();
        Move();
    }

    /**
    * Takes damage when getting shot
    */
    public void TakeDamage(float damage){
        health -= damage;
        if(health <= 0){
            Destroy(this.gameObject);
        }
    }
    private void Shoot() {
    //     // translated 3d instantiating to 2d, I hope you guys don't look too much into how this works
         if (GameManager.instance.player && Time.time > fireTime) {
            //         Debug.Log("stuff");
            //         transform.right = GameManager.instance.player.transform.position - transform.position;
            EnemyProjectile p = Instantiate(projectile, transform.position, Quaternion.identity);
    //         a.transform.position = transform.position;

             fireTime = Time.time + fireRate;
         }
     }

    /**
    * If the player collides with the enemy, do damage to player for however long the player is withing the enemy
    */
    private void Move() {
        float step = moveSpeed * Time.deltaTime;

        // move sprite towards the target location
        transform.position = Vector2.MoveTowards(transform.position, GameManager.instance.player.transform.position, step);
    }
    void OnTriggerStay2D(Collider2D other){
        if (other.transform.tag == "Player" && Time.time > damageTime && other is BoxCollider2D){
            other.transform.GetComponent<Player>().TakeDamage(damage);
            damageTime = Time.time + damageRate;
        }
    }
}
