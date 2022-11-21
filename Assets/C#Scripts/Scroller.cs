using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// had an idea to make a scrollable background for the menu,
// but can't find a decent pic that looks 'scrollable'
// if you guys find one, screw around with the x and y values
public class Scroller : MonoBehaviour
{
   	[SerializeField] private RawImage img;
   	[SerializeField] private float x, y;
    // Update is called once per frame
    void Update()
    {
        img.uvRect = new Rect(img.uvRect.position + new Vector2(x,y) * Time.deltaTime,img.uvRect.size);
    }
}
