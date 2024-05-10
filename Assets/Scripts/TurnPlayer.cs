using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public Sprite dclawe;
    public Sprite dclaws;
    public Sprite dclaww;
    public Sprite dclawn;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            GetComponent<SpriteRenderer>().sprite = dclawn;
        }
        if (Input.GetKeyDown("s"))
        {
            GetComponent<SpriteRenderer>().sprite = dclaws;
        }
        if (Input.GetKeyDown("a"))
        {
            GetComponent<SpriteRenderer>().sprite = dclaww;
        }
        if (Input.GetKeyDown("d"))
        {
            GetComponent<SpriteRenderer>().sprite = dclawe;
        }
    }
}
