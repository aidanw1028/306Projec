using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HeavyEnemy : MonoBehaviour
{  
	// Core vars
    private float health = 100.0f;
    [SerializeField] private float moveSpeed = 0.5f;
    [SerializeField] private float damage = 0.0f;
    [SerializeField] private float damageRate = 0.2f;
    private float damageTime;
        

    //projectile vars
    [SerializeField] private HeavyEnemyProjectile projectile;
    [SerializeField] private float fireRate = 3.0f;
    [SerializeField] private float fireTime;
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private float KnockbackDelay = 0.15f;
    public UnityEvent OnBegin, OnDone;

    public Healthpack healthPack;
    private float healthProb = 15;


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
            GameManager.instance.AddPoints(5);
        }
    }
    private void Shoot() {
         if (GameManager.instance.player && Time.time > fireTime) {
            HeavyEnemyProjectile p = Instantiate(projectile, transform.position, Quaternion.identity);

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
        var tempColor = "FF004A";
        var m_Red = System.Convert.ToByte(tempColor.Substring(0, 2), 16);
        var m_Green = System.Convert.ToByte(tempColor.Substring(2, 2), 16);
        var m_Blue = System.Convert.ToByte(tempColor.Substring(4, 2), 16);

        // always requires the alpha parameter
        Color originalColor = this.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color ; //get current color
        float flashingFor = 0; 
        float flashSpeed = 0.125f; 
        Color flashColor = new UnityEngine.Color32(m_Red, m_Green, m_Blue, 255);
        float flashTime = 0.255f; // flash for this much time
        var newColor = flashColor;
        while(flashingFor<flashTime) {
            this.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = newColor;
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

    public void increaseStats() {
        health += 10.0f;
        projectile.GetComponent<HeavyEnemyProjectile>().increaseDMG();
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

