using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform posLeft;
    public Transform posRight;
    public float speed = 1f;
    //false is left true is right
    public bool side = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("Space Pressed");
            if(side)
            {
                //move left
                side = false;
            }
            else
            {
                //move right
                side = true;
            }
        }

        if(side)
        {
            // Move our position a step closer to the target.
            Debug.Log("Moving Left");
            var step =  speed * Time.deltaTime; // calculate distance to move
            float newX = Vector3.MoveTowards(transform.position, posLeft.position, step).x;
            transform.position = new Vector3 (newX, transform.position.y, transform.position.z);
        }
        else
        {
            // Move our position a step closer to the target.
            Debug.Log("Moving Right");
            var step =  speed * Time.deltaTime; // calculate distance to move
            float newX = Vector3.MoveTowards(transform.position, posRight.position, step).x;
            transform.position = new Vector3 (newX, transform.position.y, transform.position.z);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the collided object has the "Enemy" tag
        if (other.CompareTag("Enemy"))
        {
            // Destroy the player object
            Destroy(gameObject);
        }
    }
}
