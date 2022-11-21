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

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (Time.time >= fireTime)
        {
            ShotgunBullet a = Instantiate(projectile, transform.position, transform.rotation);
            a.ApplyMultipliers(damageMultiplier, knockbackMultiplier, speedMultiplier);
            a.SetDirection(0.4f);

            ShotgunBullet b = Instantiate(projectile, transform.position, transform.rotation);
            b.ApplyMultipliers(damageMultiplier, knockbackMultiplier, speedMultiplier);
            b.SetDirection(0.2f);

            ShotgunBullet c = Instantiate(projectile, transform.position, transform.rotation);
            c.ApplyMultipliers(damageMultiplier, knockbackMultiplier, speedMultiplier);
            c.SetDirection(0.0f);

            ShotgunBullet d = Instantiate(projectile, transform.position, transform.rotation);
            d.ApplyMultipliers(damageMultiplier, knockbackMultiplier, speedMultiplier);
            d.SetDirection(-0.2f);

            ShotgunBullet e = Instantiate(projectile, transform.position, transform.rotation);
            e.ApplyMultipliers(damageMultiplier, knockbackMultiplier, speedMultiplier);
            e.SetDirection(-0.4f);

            // Sets the firedelay for player
            fireTime = Time.time + fireRate;
        }
    }

    private void IncreaseFireRate(float t)
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
}
