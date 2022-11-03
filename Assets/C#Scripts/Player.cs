using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float health = 500.0f;
    [SerializeField] private float moveSpeed = 10.0f;
    [SerializeField] private float damage = 50.0f;
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
    public void TakeDamage(float damage) {
        health -=damage;
        if(health<=0) {
            Destroy(this.gameObject);
        }

    }

    // void OnCollisionEnter2D( Collision2D col){
    //     if (col.collider == true){
    //         Debug.Log("SUP:");
    //     }
    // }
}
