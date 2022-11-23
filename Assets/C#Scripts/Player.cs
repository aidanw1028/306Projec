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
    private float maxHealth = 500.0f;

    // Shield vars
    [SerializeField] private Shield shield;
    private bool hasShield = true;
    private float rechargeTime = 5.0f; // The Recharge time of the shield
    private float shieldTime; // Time since shield was last used

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
        UseShield();

        //set bounds for the player between the edges of the road
        if (transform.position.y >= -1)
        {
            transform.position = new Vector3(transform.position.x, -1, 0);
        }
        else if (transform.position.y <= -4.5)
        {
            transform.position = new Vector3(transform.position.x, (float)-4.5, 0);
        }

    }

    void MovePlayer() {
        //rb.velocity = new Vector2(movement.x, movement.y) * moveSpeed*Time.deltaTime;
        movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rb.velocity = movement * moveSpeed;

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
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
        //Debug.Log(health);
    }

    public void HealPlayer(float heal){
        if(health + heal < maxHealth){
            health += heal;
            healthbar.addHealth(heal);
        }
        else{
            health = maxHealth;
            healthbar.SetMaxHP(health);
        }
    }


    void OnTriggerEnter2D(Collider2D other){
        if (other.transform.tag == "Enemy"){
            //Debug.Log("SWING!");
        }

    }
}
