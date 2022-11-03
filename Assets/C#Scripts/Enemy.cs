using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float health = 100.0f;
    [SerializeField] private float moveSpeed = 3.0f;
    [SerializeField] private float damage = 25.0f;
    [SerializeField] private float damageRate = 0.2f;
    private float damageTime;
    // Start is called before the first frame update
  
    void Update() {
    }

    void Awake(){
        
        // gameObject.AddComponent<BoxCollider2D>();

        // Rigidbody2D rb = gameObject.AddComponent<Rigidbody2D>();
        // rb.bodyType = RigidbodyType2D.Dynamic;
    }

    void OnTriggerStay2D(Collider2D other){
        if (other.transform.tag == "Player" && Time.time > damageTime){
            other.transform.GetComponent<Player>().TakeDamage(damage);
            damageTime = Time.time + damageRate;
        }
    }
}
