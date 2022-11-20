using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private float lifeTime = 0.6f;
    private float moveSpeed = 7.0f;
    private float dmg = 20.0f;
    private float knockBackstrength = 6;

    void Start()
    {
        Destroy(this.gameObject, lifeTime);
    }

    public void SetDirection(float direction)
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(1, direction).normalized * moveSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Enemy")
        {
            float variation = Random.Range(-4.0f, 4.0f);

            other.transform.GetComponent<Enemy>().TakeDamage(dmg+variation);
            other.transform.GetComponent<Enemy>().PlayFeedback(this.gameObject, knockBackstrength);
            Destroy(this.gameObject);
        }
    }
}
