using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthpack : MonoBehaviour
{
    private float healAmount = 50.0f;

    void OnTriggerEnter2D(Collider2D other){
        if (other.transform.tag == "Player"){
            other.transform.GetComponent<Player>().HealPlayer(healAmount);
            Destroy(this.gameObject);
        }
    }
}
