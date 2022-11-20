using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField] private float lifeTime = 2.5f;
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float dmg = 25.0f;
    [SerializeField] private float knockBackstrength = 8;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(1, 0).normalized * moveSpeed;
        Destroy(this.gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D other) {
    	if (other.transform.tag == "Enemy") {

            float variation = Random.Range(-5.0f, 5.0f);
    		other.transform.GetComponent<Enemy>().TakeDamage(dmg+variation);
            other.transform.GetComponent<Enemy>().PlayFeedback(this.gameObject, knockBackstrength);
            Destroy(this.gameObject);
    	}
    }

    public void IncreaseDamage(float d)
    {
        dmg += d;
    }
}
