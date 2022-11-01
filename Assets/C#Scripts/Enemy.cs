using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float health = 100.0f;
    [SerializeField] private float moveSpeed = 3.0f;
    [SerializeField] private float damage = 50.0f;
    [SerializeField] private float damageRate = 1.0f;
    private float damageTime;
    // Start is called before the first frame update
  
    void Update() {
        
    }

    void Awake(){
        
        // gameObject.AddComponent<BoxCollider2D>();

        // Rigidbody2D rb = gameObject.AddComponent<Rigidbody2D>();
        // rb.bodyType = RigidbodyType2D.Dynamic;
    }

    void OnCollisionEnter2D( Collision2D col){
        if (col.collider == true){
            Debug.Log("SUP:");
        }
    }
}
