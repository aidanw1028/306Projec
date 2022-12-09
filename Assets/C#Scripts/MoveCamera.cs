using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject refObj;
    public float camSpeed = 0.50f;
    private float scaleTime = 10.0f;
    private float camTime;
    void Start()
    {
        
    }

    private float delay = 2f;
    // Update is called once per frame
    void Update()
    {
    	if (refObj != null) {
			transform.position += Vector3.right * Time.deltaTime *  camSpeed;    	
            }
    	else {
    		// Invoke takes 2 args, function name and the amount of delay till scene reloads
    		Debug.Log("Game Over");
    		Invoke("Restart", delay);
    	}

        scaleSpeed();
    }

    void Restart() {
    	SceneManager.LoadScene("MainMenu");
    }
    
    private void scaleSpeed(){
        if(Time.time >= camTime){
            camSpeed += 0.05f;

            camTime = Time.time + scaleTime;
        }
    }

    /**
    *If the player exits the Camera, they die
    */
    void OnTriggerExit2D(Collider2D other){
        if(other.transform.tag == "Player"){
            Destroy(refObj);
        }

        if(other.transform.tag == "Enemy"){
            other.transform.GetComponent<Enemy>().TakeDamage(1000000);
        }        
    }
}
