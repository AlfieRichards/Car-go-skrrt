using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotFix : MonoBehaviour
{
    public Transform target;

    private void Start() {
        target = transform.parent.gameObject.transform;
    }

    void Update()
    {
        // Rotate the camera every frame so it keeps looking at the target
        transform.LookAt(target);
    }
}
