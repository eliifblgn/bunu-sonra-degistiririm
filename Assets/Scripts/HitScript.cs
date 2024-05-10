using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class SeekPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer sprite1;
    public SpriteRenderer sprite2;
    public Sprite n;
    public Sprite e;
    public Sprite s;
    public Sprite w;
    public float speed = 2.0f;
    private Transform target;
    private Component col;
    private float vurmaCooldown;
    private float vurusHizi = 0.7f;
    public AudioSource[] hitAudio;
    public GameObject meat;
    private Vector3 offset = new Vector3(-5, -5, 0);
    private GameObject adam;
    void Start()
    {
        adam = GameObject.Find("Player");
        target = GameObject.Find("Player").transform;
        col = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()
    {
        if(Time.time > vurmaCooldown)
        {
            vurmaCooldown = Time.time + vurusHizi;
            GetComponent<HealthSystem>().health -= 5;
            hitAudio[Random.Range(0, 4)].Play();
            Instantiate(sprite1, transform.position, transform.rotation);
            adam.GetComponent<HealthSystem>().xp += 1;
        }
        if(GetComponent<HealthSystem>().health <= 0.0)
        {
            Instantiate(meat, transform.position, transform.rotation);
        }
    }

}
