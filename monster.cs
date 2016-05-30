using UnityEngine;
using System.Collections;

public class monster : MonoBehaviour
{
    public float speed = 10;
    int hpCount = 0;
    public GameObject HP;
    public Sprite[] hp;
    Transform tr;
    SpriteRenderer sr;

    // Use this for initialization
    void Start()
    {
        tr = GetComponent<Transform>();
        //sr = GetComponent<SpriteRenderer>();
        sr = HP.GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "bullet")
        {
            hpCount++;
        }
    }
    // Update is called once per frame
    void Update()
    {
        tr.transform.Translate(0, -speed * Time.deltaTime, 0);
        if (tr.transform.position.y < -6)
        {
            Destroy(gameObject);
        }
        if (hpCount == 0)
            sr.sprite = hp[0];
        else if (hpCount == 1)
            sr.sprite = hp[1];
        else if (hpCount == 2)
            sr.sprite = hp[2];
        else if(hpCount == 3)
            Destroy(gameObject);
    }
}
