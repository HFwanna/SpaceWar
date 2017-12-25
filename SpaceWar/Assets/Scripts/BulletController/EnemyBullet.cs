using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {
    //爆炸效果
    public GameObject explode;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 3);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * 10);
	}

    void OnTriggerEnter(Collider others)
    {
        if(others.tag == "Player")
        {
            Instantiate(explode, transform.position, Quaternion.identity);
            Destroy(gameObject);
            GameObject.Find("GameController").GetComponent<AddScore>().BloodNumber -= 1;

        }
    }
}
