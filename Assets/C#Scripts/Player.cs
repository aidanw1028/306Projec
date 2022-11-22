using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // hp vars
    [SerializeField] public float health = 500.0f;
    [SerializeField] private float moveSpeed = 3.0f;
    [SerializeField] private float damage = 50.0f;
    [SerializeField] public HealthBar healthbar;

    // projectile vars
    [SerializeField] private Projectile projectile;
    [SerializeField] private float fireRate = 5.0f;
    [SerializeField] private float fireTime;

    // Shield vars
    [SerializeField] private Shield shield;
    private bool hasShield = true;
    private float rechargeTime = 5.0f;
    private float shieldTime;

    public Rigidbody2D rb;  
    public Vector3 movement;

    Vector2 playerPos;

    Vector2 TruePlayerPos;

    public Camera mainCam;
    // Start is called before the first frame update
    void Start()
    {
        healthbar.SetMaxHP(health);
        playerPos = gameObject.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Shoot();
        UseShield();

    }

    void MovePlayer() {
        //rb.velocity = new Vector2(movement.x, movement.y) * moveSpeed*Time.deltaTime;
        movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rb.velocity = movement * moveSpeed;

        // if(Input.GetKey(KeyCode.W)) {
        //     transform.position += Vector3.up *moveSpeed*Time.deltaTime;
        //     }
        // if(Input.GetKey(KeyCode.S)) {
        //     transform.position += Vector3.down * moveSpeed*Time.deltaTime;
        //     }
        // if(Input.GetKey(KeyCode.A)) {
        //     transform.position += Vector3.left * moveSpeed*Time.deltaTime;
        //     }
        // if(Input.GetKey(KeyCode.D)) {
        //     transform.position += Vector3.right * moveSpeed*Time.deltaTime;
        //     }
    }

    void UseShield(){
        if(Input.GetKey(KeyCode.Space) && hasShield is true && Time.time >= shieldTime){
            Shield s = Instantiate(shield, transform.position + (transform.right),transform.rotation);

            shieldTime = Time.time + rechargeTime;
        }
    }


    /**
    * Player takes damage if shot
    */
    public void TakeDamage(float damage) {
        health -=damage;
        healthbar.SetHealth(damage);
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

    void OnTriggerEnter2D(Collider2D other){
        if (other.transform.tag == "Enemy"){
            Debug.Log("SWING!");
        }

    }
}
