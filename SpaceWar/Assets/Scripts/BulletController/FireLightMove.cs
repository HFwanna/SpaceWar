using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLightMove : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
        Destroy(gameObject, 1);
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("FireLightPoint") != null)
        {
            transform.position = GameObject.Find("FireLightPoint").transform.position + new Vector3(0, -6.25f, 0);
        }
	}
}
