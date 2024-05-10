using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDelete : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > 30)
        {
           Destroy(gameObject);
        }
    }
}
