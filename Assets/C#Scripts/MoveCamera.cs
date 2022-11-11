using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * Time.deltaTime * 0.50f;
    }

    /**
    *If the player exits the Camera, they die
    */
    void OnTriggerExit2D(Collider2D other){
        if(other.transform.tag == "Player"){
            other.transform.GetComponent<Player>().TakeDamage(1000000000);
        }
    }
}
