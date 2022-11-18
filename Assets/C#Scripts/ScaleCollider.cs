using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleCollider : MonoBehaviour
{
    public Camera cam;
    public BoxCollider2D box;
    // Start is called before the first frame update
    void Start()
    {
        var aspect = (float)Screen.width / (float)Screen.height;
        var orthoSize = cam.orthographicSize;
 
        var width = 2.0f * orthoSize * aspect;
        var height = 2.0f * cam.orthographicSize;
 
        box.size = new Vector2(width, height);     
    }
}
