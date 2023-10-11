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
        float tempSpeed = 0f;
        if(timeOfDay > 2f && timeOfDay < 22f)
        {
            tempSpeed = orbitSpeed * 20f;
        }
        else{tempSpeed = orbitSpeed;}
        timeOfDay += Time.deltaTime * tempSpeed;
        if(timeOfDay > 24f)
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
        float sunRotation = Mathf.Lerp(-15, 195, alpha);
        Debug.Log(sunRotation);
        
        //sun.transform.rotation.eulerAngles.y = sunRotation;
        sun.transform.rotation = Quaternion.Euler(sunRotation, -150f, 0);
    }

}
