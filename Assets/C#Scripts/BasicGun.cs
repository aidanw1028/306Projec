using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGun : MonoBehaviour


{
    [SerializeField] private Projectile projectile;
    [SerializeField] private static float fireRate = 1.0f;
    [SerializeField] private float fireTime;
    private bool dupeShot = false;
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
            Projectile a = Instantiate(projectile, transform.position, transform.rotation);
            a.ApplyMultipliers(damageMultiplier, knockbackMultiplier, speedMultiplier);

            if (dupeShot)
            {
                Projectile b = Instantiate(projectile, transform.position, transform.rotation);
                b.transform.position = new Vector2(b.transform.position.x, b.transform.position.y - 0.3f);
                b.ApplyMultipliers(damageMultiplier, knockbackMultiplier, speedMultiplier);
            }

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

    public void SetMultishot()
    {
        dupeShot = !dupeShot;
    }


}
