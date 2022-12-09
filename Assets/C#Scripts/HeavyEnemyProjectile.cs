using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyEnemyProjectile : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    [SerializeField] private float lifeTime = 7.5f;
    [SerializeField] private float moveSpeed = 2.5f;
    public float dmg = 50.0f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * moveSpeed;
        direction.Normalize();
        float rot = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);

        Destroy(this.gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player" && other is BoxCollider2D)
        {
            other.transform.GetComponent<Player>().TakeDamage(dmg);
            Destroy(this.gameObject);
        }

        if (other.transform.tag == "Shield"){
            Destroy(this.gameObject);
        }
    }

    public void increaseDMG() {
        dmg += 10.0f;
        Debug.Log(dmg);
    }

    public void reset() {
    	dmg = 50.0f;
    }
}
