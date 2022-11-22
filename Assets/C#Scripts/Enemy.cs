using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Core vars
    [SerializeField] private float health = 100.0f;
    [SerializeField] private float moveSpeed = 1.0f;
    [SerializeField] private float damage = 25.0f;
    [SerializeField] private float damageRate = 0.2f;
    private float damageTime;
        

    //projectile vars
    [SerializeField] private EnemyProjectile projectile;
    [SerializeField] private float fireRate = 3.0f;
    [SerializeField] private float fireTime;

    [SerializeField] private SpriteRenderer objRend;  
  
    void Update() {
        Shoot();
        Move();
    }

    /**
    * Takes damage when getting shot
    */
    public void TakeDamage(float damage){
        health -= damage;
        StartCoroutine(Flicker());
        if(health <= 0){
            Destroy(this.gameObject);
        }
    }
    private void Shoot() {
         if (GameManager.instance.player && Time.time > fireTime) {
            EnemyProjectile p = Instantiate(projectile, transform.position, Quaternion.identity);
            fireTime = Time.time + fireRate;
         }
     }

    //Flicker!
    //when an enemy gets hit, flicker for .25s, then returns back to original color
    // IEnumerator basically lets unity run a function alongside proceding code statements,
    // maybe this could've been done in Update(), but whatever
    // rest of the code I got from an online documentation, so bless up
    IEnumerator Flicker() {
        Color originalColor = objRend.color; //get current color
        float flashingFor = 0; 
        float flashSpeed = 0.125f; 
        Color flashColor = Color.white;
        float flashTime = 0.25f; // flash for this much time
        var newColor = flashColor;
        while(flashingFor<flashTime) {
            objRend.color = newColor;
            flashingFor += Time.deltaTime;
            yield return new WaitForSeconds(flashSpeed); // wait this much time before object can flash again
            flashingFor += flashSpeed;
            // return colors back to original value, if needed.
            if (newColor == flashColor) {
                newColor = originalColor;
            }
            else {
                newColor = flashColor;
            }
        }

    }

    
    private void Move() {
        float step = moveSpeed * Time.deltaTime;

        // move sprite towards the target location
        if (GameManager.instance.player != null) {
            transform.position = Vector2.MoveTowards(transform.position, GameManager.instance.player.transform.position, step);
        }
    }
    /**
    * If the player collides with the enemy, do damage to player for however long the player is withing the enemy
    */
    void OnTriggerStay2D(Collider2D other){
        if (other.transform.tag == "Player" && Time.time > damageTime && other is BoxCollider2D){
            other.transform.GetComponent<Player>().TakeDamage(damage);
            damageTime = Time.time + damageRate;
        }
    }
}
