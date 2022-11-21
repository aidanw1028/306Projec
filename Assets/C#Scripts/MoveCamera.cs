using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject refObj;
    private float delay = 2f;
    // Update is called once per frame
    void Update()
    {
    	if (refObj != null) {
			transform.position += Vector3.right * Time.deltaTime * 0.50f;    	}
    	else {
    		// Invoke takes 2 args, function name and the amount of delay till scene reloads
    		Debug.Log("Game Over");
    		Invoke("Restart", delay);
    	}
    }

    void Restart() {
    	SceneManager.LoadScene("MainMenu");
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
