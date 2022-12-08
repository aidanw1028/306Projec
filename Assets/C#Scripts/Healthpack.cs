using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthpack : MonoBehaviour
{
    private float healAmount = 80.0f;

    void OnTriggerEnter2D(Collider2D other){
        if (other.transform.tag == "Player" && other is BoxCollider2D){
            other.transform.GetComponent<Player>().HealPlayer(healAmount);
            Destroy(this.gameObject);
        }
    }
}
