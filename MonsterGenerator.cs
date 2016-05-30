using UnityEngine;
using System.Collections;

public class MonsterGenerator : MonoBehaviour
{
    public GameObject[] monster;
    private int monsterNum;
    private float selfTimer = 0.0f;
   
    // Use this for initialization
    void Start()
    {
        selfTimer = 0.7f;
    }

    // Update is called once per frame
    void Update()
    {
        monsterNum = Random.Range(0, 2);
        Debug.Log(monsterNum);
        if (selfTimer < Time.time)
        {
            monster[monsterNum].transform.position = this.transform.position;
            Instantiate<Object>(monster[monsterNum]);
            selfTimer = Time.time + 1.0f;
        }

    }
}
