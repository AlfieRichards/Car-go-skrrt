using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotFix : MonoBehaviour
{
    //https://docs.unity3d.com/ScriptReference/Transform.LookAt.html
    //https://docs.unity3d.com/ScriptReference/Vector3.Slerp.html
    
    public Transform sphere; // Reference to the sphere GameObject
    public float rotationSpeed = 10f;
    public Vector3 rotOffset;

    private void Start() {
        sphere = transform.parent.gameObject.transform;
    }

    private void Update()
    {
        // Calculate the direction from the sphere to the rotating object
        Vector3 toSphere = sphere.position - transform.position;

        // Calculate the rotation that aligns the object's forward vector with toSphere
        Quaternion targetRotation = Quaternion.LookRotation(toSphere);

        // Invert the rotation to prevent the object from being upside down
        targetRotation *= Quaternion.Euler(rotOffset);

        // Smoothly interpolate between the current rotation and the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Rotate the object around the sphere
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
