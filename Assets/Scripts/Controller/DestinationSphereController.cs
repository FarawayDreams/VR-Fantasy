using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationSphereController : MonoBehaviour
{
    public float SleepTime;
    public float temp;
    public KeyAndMouseManager manager;
    void Awake()
    {
        SleepTime = 3f;
        temp = SleepTime;
    }
    private void FixedUpdate()
    {
        temp -= Time.deltaTime;
        if (temp <= 0)
        {
            manager.isRightClick = false ;
            temp = SleepTime;
            Sleep();
        }
    }
    void Sleep()
    {
        gameObject.SetActive(false);
    }

}
