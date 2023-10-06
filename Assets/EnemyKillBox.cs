using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKillBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object has the "Enemy" tag
        if (other.CompareTag("Enemy"))
        {
            // Destroy the enemy object
            Destroy(other.gameObject);
        }
    }
}
