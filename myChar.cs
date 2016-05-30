using UnityEngine;
using System.Collections;

public class myChar : MonoBehaviour {
    public float speed = 5;
    public GameObject bullet;
    public bool deathCheck = false;
    private float selfTimer = 0.0f;
    // Use this for initialization
	void Start () {
        selfTimer = Time.time + 0.1f;
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "monster")
            deathCheck = true;
    }
	
	// Update is called once per frame
	void Update () {
        // 총알 발사
        if (selfTimer < Time.time){
            bullet.transform.position = this.transform.position;
            Instantiate<Object>(bullet);
            selfTimer = Time.time + 0.1f;
        }
        // 양 끝 이동 불가
        if (transform.position.x < -3.55)
            transform.position = new Vector3((float)-3.55, this.transform.position.y, this.transform.position.z);
        if (transform.position.x > 3.55)
            transform.position = new Vector3((float)3.55, this.transform.position.y, this.transform.position.z);

        // 이동
        float translation = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(translation, 0, 0);
        // 죽으면
        if (deathCheck)
            Application.LoadLevel("Main");
    }

}
