using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGun : MonoBehaviour


{
    [SerializeField] private Projectile projectile;
    [SerializeField] private float fireRate = 2.0f;
    [SerializeField] private float fireTime;

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

            // Sets the firedelay for player
            fireTime = Time.time + fireRate;
        }
    }
}
