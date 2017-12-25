using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleBossCollider : MonoBehaviour {
    //引入要传递的gameObject
    public GameObject LittleBoss;
    //爆炸效果
    public GameObject explosion;
    //小飞机血量
    private int blood = 100;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //小飞机血量小于0死亡
        if (blood <= 0)
        {
            //调用LittleBoss下的Destroy方法摧毁小飞机这个物体
            LittleBoss.SendMessage("Destroy");
        }
	}

    void OnTriggerEnter(Collider others)
    {
        //碰撞物体是player就摧毁小飞机，扣player一滴血
        if(others.tag == "Player")
        {
            GameObject.Find("GameController").GetComponent<AddScore>().BloodNumber -= 1;
            LittleBoss.SendMessage("Destroy");
            Instantiate(explosion,this.transform.position,Quaternion.identity);
        }

        //碰撞物体是子弹就扣小飞机20点血
        if (others.tag == "bullet")
        {
            blood -= 20;
        }

        //碰到若是激光
        if (others.tag == "ThunderFireLight")
        {
            blood -= 20;
        }

    }

    void OnTriggerStay(Collider others)
    {
        if (others.tag == "ThunderFireLight")
        {
            blood -= 20;
        }
    }
}
