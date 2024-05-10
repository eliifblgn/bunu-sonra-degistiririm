using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class NPCMovement : MonoBehaviour
{
    private bool isDead = false;
    public AudioSource[] deathAudio;
    public AudioSource[] barkAudio;
    public float speed = 2.0f;
    private Transform target;
    private Vector3 lastLocation;
    private Vector3 currentLocation;
    private bool isAttacking = false;
    private bool isAlert = false;
    private float attackCooldown;
    private float attackSpeed = 1.0f;
    private Rigidbody2D enemyRb;
    private string direction;
    public float chargeForce = 10;
    private GameObject adam;
    private float playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform;
        InvokeRepeating("lastPos", 0f, 1.3f);
        enemyRb = GetComponent<Rigidbody2D>();
        adam = GameObject.Find("Player");
        playerHealth = GameObject.Find("Player").GetComponent<HealthSystem>().health;
    }

    // Update is called once per frame
    void Update()
    {
        currentLocation = transform.position;
        float dist = Vector3.Distance(target.position, transform.position);

        //TODO: bu siktigimin kodu bi turlu calismiyo nasil yazdiysam buna bi bakmak lazim. kafama sikicam
        /* if (dist < 4 && isDead == false)
         {
             var step = speed * Time.deltaTime;
             transform.position = Vector3.MoveTowards(transform.position, target.position + offset, step);
         } */
        if(playerHealth < 0)
        {
            Destroy(GetComponent<NPCMovement>());
        }
        if (dist < 15 && isDead == false && isAlert == false)
        {
            barkAudio[Random.Range(0, 4)].Play();
            isAlert = true;
        }
        //Debug.Log(Time.time);
        //Debug.Log(adam.GetComponent<HealthSystem>().health);
        if (dist < 15 && isDead == false && isAttacking == false)
        {
            var step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
       if (isDead == false && dist < 3 && isAttacking == false) 
        {
            isAttacking = true;
            if(direction == "west")
            {
                enemyRb.AddForce(Vector2.left * 5, ForceMode2D.Force);
            }
            if (direction == "east")
            {
                enemyRb.AddForce(Vector2.right * 5, ForceMode2D.Force);

            }
            if (direction == "north")
            {
                enemyRb.AddForce(Vector2.up * 5, ForceMode2D.Force);

            }
            if (direction == "south")
            {
                enemyRb.AddForce(Vector2.down * 5, ForceMode2D.Force);

            }
        }
       
        else
        {
            isAttacking = false;
        }

        //burda isDead degiskeninin amaci bu donguyu sadece bir kere yurutmek. bir canavar oldugunde olan butun olaylar bu if dongusu icinde
        if (GetComponent<HealthSystem>().health <= 0.0 && isDead == false)
        {
            transform.Rotate(0, 0, 90);
            Destroy(GetComponent<NPCMovement>());
            Destroy(GetComponent<BoxCollider2D>());
            deathAudio[Random.Range(0, 4)].Play();
            adam.GetComponent<HealthSystem>().xp += 5;
            //audio3.Play();
            //Instantiate(sprite2, transform.position, transform.rotation); buraya daha uygun bir sprite bulacagim
            isDead = true;
        }
        if(currentLocation.x > lastLocation.x)
        {
            GetComponent<SpriteRenderer>().sprite = GetComponent<SeekPlayer>().e;
            direction = "east";
        }
        else
        {
            if (currentLocation.x < lastLocation.x)
            {
                GetComponent<SpriteRenderer>().sprite = GetComponent<SeekPlayer>().w;
                direction = "west";
            }
        }
        if (currentLocation.y - 1.0f > lastLocation.y)
        {
            GetComponent<SpriteRenderer>().sprite = GetComponent<SeekPlayer>().n;
            direction = "north";
        }
        else
        {
            if (currentLocation.y + 1.0f < lastLocation.y)
            {
                GetComponent<SpriteRenderer>().sprite = GetComponent<SeekPlayer>().s;
                direction = "south";
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            adam.GetComponent<HealthSystem>().health -= 5;
        }
    }
    Vector3 lastPos()
    {
        lastLocation = transform.position;
        return lastLocation;
    }
}

