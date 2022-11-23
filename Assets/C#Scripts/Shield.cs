using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] private float lifeTime = 2.0f;
    private float moveSpeed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        moveShield();
    }

    void moveShield(){
        float step = moveSpeed * Time.deltaTime;

        // move shield towards the target location
        // transform.position = Vector2.MoveTowards(transform.position, GameManager.instance.player.transform.position + (transform.right), step);
       transform.position = GameManager.instance.player.transform.position;
    }
}
