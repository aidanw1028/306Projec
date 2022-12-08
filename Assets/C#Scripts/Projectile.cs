using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Transform damagePopup;
    private Rigidbody2D rb;
    [SerializeField] private float lifeTime = 2.5f;
    [SerializeField] private float moveSpeed = 8.0f;
    [SerializeField] private float dmg = 25.0f;
    [SerializeField] private float knockBackstrength = 8;
    private int critChance = 4;
    private float critMultiplier = 1.75f;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        float direction = GameManager.instance.player.transform.forward.z;
        rb.velocity = new Vector2(direction, 0).normalized * moveSpeed;
        Destroy(this.gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D other) {
    	if (other.transform.tag == "Enemy" && other is BoxCollider2D) {

            int variation = Random.Range(-5, 5);
            bool isCrit = Random.Range(0, 100) < critChance;
            if (isCrit)
            {
                dmg *= critMultiplier;
            }

            other.transform.GetComponent<Enemy>().TakeDamage(dmg+variation);
            other.transform.GetComponent<Enemy>().PlayFeedback(this.gameObject, knockBackstrength);
            DamagePopup.Create(other.transform.GetComponent<Enemy>().transform.position, (int)dmg+variation, damagePopup, isCrit);
            Destroy(this.gameObject);
    	}
    }
    void OnCollisionEnter2D(Collision2D other) {
        if (other.transform.tag == "Wall") {
            other.transform.GetComponent<Obstacle>().TakeDamage(dmg);
            Destroy(this.gameObject);
        }
    }

    public void ApplyMultipliers(float damage, float knockback, float speed, int chance, float multiplier)
    {
        dmg = dmg * damage;
        knockBackstrength = knockBackstrength * knockback;
        moveSpeed = moveSpeed * speed;
        critChance = chance;
        critMultiplier = multiplier;
    }
}
