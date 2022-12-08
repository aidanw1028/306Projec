using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    // Core vars
    [SerializeField] private float health = 30.0f;
    [SerializeField] private float moveSpeed = 1.0f;
    [SerializeField] private float damage = 0.0f;
    [SerializeField] private float damageRate = 0.2f;
    private float damageTime;
        

    //projectile vars
    [SerializeField] private EnemyProjectile projectile;
    [SerializeField] private float fireRate = 3.0f;
    [SerializeField] private float fireTime;
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private float KnockbackDelay = 0.15f;
    public UnityEvent OnBegin, OnDone;

    public Healthpack healthPack;
    private float healthProb = 6;


    [SerializeField] private SpriteRenderer objRend;  
  
    void Update() {
        Shoot();
        Move();
    }

    /**
    * Takes damage when getting shot
    */
    public void TakeDamage(float damage){
        //Debug.Log(damage);
        health -= damage;
        StartCoroutine(Flicker());
        if(health <= 0){
            bool willDrop = Random.Range(0, 100) < healthProb;
            if (willDrop){
                Healthpack h = Instantiate(healthPack, transform.position, Quaternion.identity);
            }
            Destroy(this.gameObject);
        }
    }
    private void Shoot() {
         if (GameManager.instance.player && Time.time > fireTime) {
            EnemyProjectile p = Instantiate(projectile, transform.position, Quaternion.identity);

            float fireRateVariation = Random.Range(-1.0f, 1.0f);
            fireTime = Time.time + fireRate+fireRateVariation;
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
        float flashTime = 0.255f; // flash for this much time
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
            if (transform.position.x < GameManager.instance.player.transform.position.x)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            } else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
    }
    /**
    * If the player collides with the enemy, do damage to player for however long the player is withing the enemy
    */
    void OnTriggerStay2D(Collider2D other){
        if (other.transform.tag == "Player" && Time.time > damageTime && other is BoxCollider2D){
            other.transform.GetComponent<Player>().TakeDamage(50);
            damageTime = Time.time + damageRate;
            Debug.Log("Enemy Hit");
        }
    }

    public void PlayFeedback(GameObject sender, float knockBackstrength)
    {
        // commenting this makes flicker work
        //StopAllCoroutines();
        OnBegin?.Invoke();
        Vector2 direction = (transform.position - sender.transform.position).normalized;
        rb2d.AddForce(direction * knockBackstrength, ForceMode2D.Impulse);
        StartCoroutine(Reset());
    }

    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(KnockbackDelay);
        rb2d.velocity = Vector3.zero;
        OnDone?.Invoke();
    }
}
