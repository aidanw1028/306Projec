using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float health = 500.0f;
    [SerializeField] private float moveSpeed = 10.0f;

    // Shield vars
    [SerializeField] private Shield shield;
    private bool hasShield = true;
    private float rechargeTime = 5.0f; // The Recharge time of the shield
    private float shieldTime; // Time since shield was last used

    Vector2 playerPos;

    Vector2 TruePlayerPos;

    public Camera mainCam;
    // Start is called before the first frame update
    void Start()
    {
        playerPos = gameObject.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        UseShield();

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
        if(health<=0) {
            Destroy(this.gameObject);
        }

    }


    void OnTriggerEnter2D(Collider2D other){
        if (other.transform.tag == "Enemy"){
            //Debug.Log("SWING!");
        }

    }
}
