using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldRotation : MonoBehaviour
{
    public float rotationSpeed  = 45f;
    public bool rotation = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(rotation)
        {
            // Get the current rotation as a Quaternion.
            Quaternion currentRotation = transform.rotation;

            // Calculate the desired rotation amount around the x-axis.
            float rotationAmount = rotationSpeed * Time.deltaTime;

            // Create a new Quaternion for the desired rotation.
            Quaternion rotationDelta = Quaternion.Euler(rotationAmount, 0, 0);

            // Apply the new rotation to the transform.
            transform.rotation = currentRotation * rotationDelta;
        }
    }
}
