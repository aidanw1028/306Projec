using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject refObj;
    private float camSpeed = 0.50f;
    private float scaleTime = 10.0f;
    private float camTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	if (refObj != null) {
			transform.position += Vector3.right * Time.deltaTime *  camSpeed;    	
            }
    	else {
    		SceneManager.LoadScene("MainMenu");
    	}

        scaleSpeed();
    }
    
    private void scaleSpeed(){
        if(Time.time >= camTime){
            camSpeed += 0.01f;

            Debug.Log("Speed Up");
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
    }
}
