using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject refObj;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	if (refObj != null) {
			transform.position += Vector3.right * Time.deltaTime * 0.50f;    	}
    	else {
    		SceneManager.LoadScene("MainMenu");
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
