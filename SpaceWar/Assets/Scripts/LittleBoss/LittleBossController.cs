using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleBossController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy(gameObject, 3);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3(0, 0, -1) * Time.deltaTime * 9);
	}
    //摧毁小飞机这个物体
    void Destroy()
    {
        Destroy(gameObject);
    }


}

