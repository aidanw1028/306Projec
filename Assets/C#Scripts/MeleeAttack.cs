using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    private float rechargeTime = 10.0f; // The Recharge time of the shield
    private float slashTime; // Time since slash was last used

    private float dmg = 30.0f;

    public Transform damagePopup;
    private float knockBackstrength = 6;
    private float critChance = 10;
    private float critMultiplier = 1.50f;
    public AudioSource audioSource;
    public AudioClip shootingClip;

    public GameObject attackEffect;

    void OnTriggerEnter2D(Collider2D other){
        if(other.transform.tag == "Enemy" && Time.time >= slashTime){
            int variation = Random.Range(-4, 4);
            bool isCrit = Random.Range(0, 100) < critChance;

            if (isCrit)
            {
                dmg *= critMultiplier;
            }

            GameObject effect = Instantiate(attackEffect, transform.position + (transform.right), transform.rotation);
            audioSource.PlayOneShot(shootingClip);
            Destroy(effect, 0.1f);
            other.transform.GetComponent<Enemy>().TakeDamage(dmg+variation);
            other.transform.GetComponent<Enemy>().PlayFeedback(this.gameObject, knockBackstrength);
            DamagePopup.Create(other.transform.GetComponent<Enemy>().transform.position, (int)dmg + variation, damagePopup, isCrit);

            slashTime = Time.time + rechargeTime;

            Debug.Log("Slash");

        }
    }
}
