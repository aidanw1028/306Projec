using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    [SerializeField] private ShotgunBullet projectile;
    private float fireRate = 2.5f;
    private float fireTime;

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
            a.SetDirection(0.4f);

            ShotgunBullet b = Instantiate(projectile, transform.position, transform.rotation);
            b.SetDirection(0.2f);

            ShotgunBullet c = Instantiate(projectile, transform.position, transform.rotation);
            c.SetDirection(0.0f);

            ShotgunBullet d = Instantiate(projectile, transform.position, transform.rotation);
            d.SetDirection(-0.2f);

            ShotgunBullet e = Instantiate(projectile, transform.position, transform.rotation);
            e.SetDirection(-0.4f);

            // Sets the firedelay for player
            fireTime = Time.time + fireRate;
        }
    }
}
