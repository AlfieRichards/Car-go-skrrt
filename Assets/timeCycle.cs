using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeCycle : MonoBehaviour
{
    //https://www.youtube.com/watch?v=H3JpkcGi8DI
    [Range(0,24)]
    public float timeOfDay;
    public GameObject sun;
    public float orbitSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeOfDay += Time.deltaTime * orbitSpeed;
        if(timeOfDay > 24)
        {
            timeOfDay = 0f;
        }
        Updatetime();
    }

    private void OnValidate()
    {
        Updatetime();    
    }

    private void Updatetime()
    {
        float alpha = timeOfDay / 24.0f;
        Debug.Log(alpha);
        float sunRotation = Mathf.Lerp(-90, 270, alpha);
        Debug.Log(sunRotation);
        
        //sun.transform.rotation.eulerAngles.y = sunRotation;
        sun.transform.rotation = Quaternion.Euler(sunRotation, -150f, 0);
    }

}
