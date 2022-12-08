using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
	private float health = 80.0f;

	public void TakeDamage(float damage) {
        health -=damage;
        if(health<=0) {
            Destroy(this.gameObject);
        }
    }
}
