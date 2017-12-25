using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCollider : MonoBehaviour {
    //碰撞体本身
    public GameObject bossCollider;

    //爆炸效果的预设体
    public GameObject explosionPrefab;

    //引入boss组件
    public GameObject boss;

    //boss血量
    public int bossBlood = 80000;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //BOSS血量低于0死亡
        if (bossBlood <= 0)
        {
            Destroy(boss);
            //其跟随的激光也应该消亡
            if (GameObject.Find("FireLight") != null)
            {
                Destroy(GameObject.Find("FireLight"));
            }
            GameObject.Find("GameController").GetComponent<AddScore>().score += 200;
        }
	}

    void OnTriggerEnter(Collider others)
    {
        if (others.tag == "bullet")
        {
            //摧毁子弹
            Destroy(others);
            //子弹爆炸
            Instantiate(explosionPrefab, others.transform.position, Quaternion.identity);
            bossBlood -= 100;
        }
        if (others.tag == "Player")
        {
            //碰到boss让你死亡
            GameObject.Find("GameController").GetComponent<AddScore>().BloodNumber = 0;
            print(GameObject.Find("GameController").GetComponent<AddScore>().BloodNumber);
            Instantiate(explosionPrefab, others.transform.position, Quaternion.identity);
        }
        if (others.tag == "ThunderFireLight")
        {
            Instantiate(explosionPrefab, others.transform.position, Quaternion.identity);
            bossBlood -= 100;
        }
    }
}
