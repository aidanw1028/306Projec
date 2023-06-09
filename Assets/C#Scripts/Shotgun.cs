using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    [SerializeField] private ShotgunBullet projectile;
    private float fireRate = 2.5f;
    private float fireTime;
    private float damageMultiplier = 1.0f;
    private float knockbackMultiplier = 1.0f;
    private float speedMultiplier = 1.0f;
    private int critChance = 5;
    private float critMultiplier = 1.75f;
    private bool upgraded = false;
    public AudioSource audioSource;
    public AudioClip shootingClip;

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }
    public void EnterBulletTime()
    {
        fireRate = fireRate/ 2.0f;
        fireTime = Time.time;
    }
    
    public void ExitBulletTime()
    {
        fireRate = fireRate * 2.0f ;
    
    }
    
    private void Shoot()
    {
        if (Time.time >= fireTime)
        {
            ShotgunBullet b = Instantiate(projectile, transform.position, transform.rotation);
            audioSource.PlayOneShot(shootingClip);
            b.ApplyMultipliers(damageMultiplier, knockbackMultiplier, speedMultiplier, critChance, critMultiplier);
            b.SetDirection(0.2f);

            ShotgunBullet c = Instantiate(projectile, transform.position, transform.rotation);
            c.ApplyMultipliers(damageMultiplier, knockbackMultiplier, speedMultiplier, critChance, critMultiplier);
            c.SetDirection(0.0f);

            ShotgunBullet d = Instantiate(projectile, transform.position, transform.rotation);
            d.ApplyMultipliers(damageMultiplier, knockbackMultiplier, speedMultiplier, critChance, critMultiplier);
            d.SetDirection(-0.2f);

            if (upgraded)
            {
                ShotgunBullet a = Instantiate(projectile, transform.position, transform.rotation);
                a.ApplyMultipliers(damageMultiplier, knockbackMultiplier, speedMultiplier, critChance, critMultiplier);
                a.SetDirection(0.4f);

                ShotgunBullet e = Instantiate(projectile, transform.position, transform.rotation);
                e.ApplyMultipliers(damageMultiplier, knockbackMultiplier, speedMultiplier, critChance, critMultiplier);
                e.SetDirection(-0.4f);
            }

            // Sets the firedelay for player
            fireTime = Time.time + fireRate;
        }
    }

    public void IncreaseFireRate(float t)
    {
        fireRate += t;
    }

    public void IncreaseDamageMultiplier(float increase)
    {
        damageMultiplier += increase;
    }

    public void IncreaseKnockbackMultiplier(float increase)
    {
        knockbackMultiplier += increase;
    }

    public void IncreaseSpeedMultiplier(float increase)
    {
        speedMultiplier += increase;
    }

    public void SetUpgrade()
    {
        upgraded = !upgraded;
    }

    public void IncreaseCritChance(int increase)
    {
        if (critChance <= 100)
        {
            critChance += increase;
        }
    }

    public void IncreaseCritMultiplier(float increase)
    {
        critMultiplier += increase;
    }
}
