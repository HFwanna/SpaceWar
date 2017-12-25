using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindSBNumer : MonoBehaviour {
    //显示核弹弹药
    public GameObject SBCount1;
    public GameObject SBCount2;
    public GameObject SBCount3;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //发射一颗减一，吃到一个弹药加一
        if (GameObject.Find("GameController").GetComponent<AddScore>().SBNumber == 3)
        {
            SBCount3.gameObject.SetActive(true);
        }
        else if (GameObject.Find("GameController").GetComponent<AddScore>().SBNumber == 2)
        {
            SBCount2.gameObject.SetActive(true);
            SBCount3.gameObject.SetActive(false);
        }
        else if (GameObject.Find("GameController").GetComponent<AddScore>().SBNumber == 1)
        {
            SBCount1.gameObject.SetActive(true);
            SBCount2.gameObject.SetActive(false);
            SBCount3.gameObject.SetActive(false);
        }
        else
        {
            SBCount1.gameObject.SetActive(false);
            SBCount2.gameObject.SetActive(false);
            SBCount3.gameObject.SetActive(false);
        }
	}
}
