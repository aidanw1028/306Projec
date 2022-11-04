using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private float lifeTime = 2.5f;
    [SerializeField] private float moveSpeed = 3.0f;
    [SerializeField] private float dmg = 25.0f;


    void Start()
    {
        Destroy(this.gameObject, lifeTime);
    }

    void Update()
    {
        MoveProjectile();
    }

    private void MoveProjectile()
    {
        transform.position -= transform.right * moveSpeed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            other.transform.GetComponent<Player>().TakeDamage(dmg);
            Destroy(this.gameObject);
        }
    }
}

