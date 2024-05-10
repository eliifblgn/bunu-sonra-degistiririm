using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    //public sprite degiskenleriyle acik ve kapali kapilarin gorunusunu belirleyebiliyoruz
    public Transform door;
    public Sprite doorclosed;
    public Sprite dooropen;
    private int ses = 1;
    //bu kod tamamen esoterik. bunu yazarken ne yaptigini sadece ben ve tanri biliyodu. artik sadece tanri biliyo
    void Start()
    {
        
    }
    void Update()
    {
        //distance door degiskeninin pozisoynundan transformda belirledigimiz ikinci degiskene olan dik uzakligi verir
        float dist = Vector3.Distance(door.position, transform.position);
        if (dist>2)
        {
            ses = 1;
        }
        if(dist<1)
        {
            //eger uzaklik 1 birimden az ise kapi acilinca collider'i sil ve gorunusunu acik yap
            GetComponent<SpriteRenderer>().sprite = dooropen;
            Destroy(GetComponent<BoxCollider2D>());
            if(ses == 1)
            {
                GetComponent<AudioSource>().Play();
                ses = 0;
            }
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = doorclosed;
        }
    }
}
