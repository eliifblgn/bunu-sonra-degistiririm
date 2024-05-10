using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HealthSystem : MonoBehaviour
{
    public float health;
    public int xp;
    public double level;
    public AudioSource levelUp;
    public int levelLimit;
    // Start is called before the first frame update
    void Start()
    {
        levelLimit = 20;
    }

    // Update is called once per frame
    void Update()
    {
        if (xp >= levelLimit)
        {
            levelUp.Play();
            levelLimit += 40;
            level += 1;
        }
    }
}
