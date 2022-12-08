using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBullet : MonoBehaviour
{
    public Transform damagePopup;
    private Rigidbody2D rb;
    private float lifeTime = 0.6f;
    private float moveSpeed = 8.0f;
    private float dmg = 25.0f;
    private float knockBackstrength = 6;
    private int critChance = 5;
    private float critMultiplier = 1.75f;

    void Start()
    {
        float health = GameManager.instance.player.health;
        float maxHealth = GameManager.instance.player.maxHealth;

        if (health < (maxHealth / 2))
        {
            critChance += 5;
            dmg += 3;
        }


        Destroy(this.gameObject, lifeTime);
    }

    public void SetDirection(float direction)
    {
        rb = GetComponent<Rigidbody2D>();
        float playerDirection = GameManager.instance.player.transform.forward.z;
        rb.velocity = new Vector2(playerDirection, direction).normalized * moveSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Enemy" && other is BoxCollider2D)
        {
            int variation = Random.Range(-4, 4);
            bool isCrit = Random.Range(0, 100) < critChance;

            if (isCrit)
            {
                dmg *= critMultiplier;
            }

            other.transform.GetComponent<Enemy>().TakeDamage(dmg+variation);
            other.transform.GetComponent<Enemy>().PlayFeedback(this.gameObject, knockBackstrength);
            DamagePopup.Create(other.transform.GetComponent<Enemy>().transform.position, (int)dmg + variation, damagePopup, isCrit);
            Destroy(this.gameObject);
        }

        if (other.transform.tag == "Wall")
        {
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
