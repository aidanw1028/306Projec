using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGun : MonoBehaviour


{
    [SerializeField] private Projectile projectile;
    [SerializeField] private static float fireRate = 0.75f;
    [SerializeField] private float fireTime;
    private bool dupeShot = false;
    private float damageMultiplier = 1.0f;
    private float knockbackMultiplier = 1.0f;
    private float speedMultiplier = 1.0f;
    private int critChance = 4;
    private float critMultiplier = 1.75f;
    public AudioSource audioSource;
    public AudioClip shootingClip;

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
            a.ApplyMultipliers(damageMultiplier, knockbackMultiplier, speedMultiplier, critChance, critMultiplier);
            audioSource.PlayOneShot(shootingClip);

            if (dupeShot)
            {
                Projectile b = Instantiate(projectile, transform.position, transform.rotation);
                b.transform.position = new Vector2(b.transform.position.x, b.transform.position.y - 0.3f);
                b.ApplyMultipliers(damageMultiplier, knockbackMultiplier, speedMultiplier, critChance, critMultiplier);
            }

            // Sets the firedelay for player
            fireTime = Time.time + fireRate;
        }
    }

    public void IncreaseFireRate(float t)
    {
        fireRate += t;
        Time.timeScale = 0;
    }

    public void IncreaseDamageMultiplier(float increase)
    {
        damageMultiplier += increase;
        Time.timeScale = 0;
    }

    public void IncreaseKnockbackMultiplier(float increase)
    {
        knockbackMultiplier += increase;
        Time.timeScale = 0;
    }

    public void IncreaseSpeedMultiplier(float increase)
    {
        speedMultiplier += increase;
        Time.timeScale = 0;
    }

    public void SetMultishot()
    {
        dupeShot = !dupeShot;
        Time.timeScale = 0;
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
