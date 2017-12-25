using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLightController : MonoBehaviour {
    //爆炸效果
    public GameObject explode;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnTriggerEnter(Collider others)
    {
        if (others.tag == "Player")
        {
            //找到飞机位置，在飞机位置引爆
            transform.position = GameObject.Find("MyPlane").transform.position;
            Instantiate(explode, transform.position, Quaternion.identity);
            GameObject.Find("GameController").GetComponent<AddScore>().BloodNumber = 0;
        }
    }

 
}
