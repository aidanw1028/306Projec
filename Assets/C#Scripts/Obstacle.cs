using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
	private float health = 80.0f;
	public Healthpack healthPack;

	public void TakeDamage(float damage) {
        health -=damage;
        if(health<=0) {
            Healthpack h = Instantiate(healthPack, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            GameManager.instance.AddPoints(2);
        }
    }
}
