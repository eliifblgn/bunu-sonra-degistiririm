using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public Vector3 playerPos = new Vector3();
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(GetComponent<HealthSystem>().xp);
        float yatayGiris = Input.GetAxisRaw("Horizontal");
        float dikeyGiris = Input.GetAxisRaw("Vertical");
        transform.Translate(Vector2.right * Time.deltaTime * speed * yatayGiris);
        transform.Translate(Vector2.up * Time.deltaTime * speed * dikeyGiris);
        if (GetComponent<HealthSystem>().health <= 0.0)
        {
            transform.Rotate(0, 0, 90);
            Destroy(GetComponent<BoxCollider2D>());
            Destroy(GetComponent<PlayerMovement>());
            Destroy(GetComponent<TurnPlayer>());
        }
    }
}
