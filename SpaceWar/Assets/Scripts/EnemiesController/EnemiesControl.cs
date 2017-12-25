using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemiesControl : MonoBehaviour {
    //爆炸效果的预设体
    public GameObject explosionPrefab;
    //敌机血量
    public int enemyBlood = 100;

    //道具预设体
    public GameObject itemPrefab;
    public GameObject itemPrefab1;
    public GameObject itemPrefab2;
    public GameObject itemPrefab3;

    //激光炮物体
    public GameObject FireLight;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 8);
	}
	
	// Update is called once per frame
	void Update () {
		//下落,space.world沿着世界坐标轴移动
        transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * 4,Space.World);
        //旋转
        transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime * 90);

        //检测血量小于0死亡
        if(enemyBlood<=0){
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            
            //敌机死亡就加分
            GameObject.Find("GameController").GetComponent<AddScore>().score+=10;
            
            //要不要产生道具
            int number = Random.Range(0, 10);
            if (number == 6)
            {
                number = Random.Range(0, 4);
                if (number == 0)
                {
                    Instantiate(itemPrefab, transform.position, Quaternion.identity);
                }
                else if (number == 1)
                {
                    Instantiate(itemPrefab1, transform.position, Quaternion.identity);
                }
                else if (number == 3)
                {
                    Instantiate(itemPrefab2, transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(itemPrefab3, transform.position, Quaternion.identity);

                }
            }
        }

        
	}

    //判断碰到了什么东西
    void OnTriggerEnter(Collider other)
    {
        
        //敌机碰到了玩家
        if(other.tag == "Player")
        {
            enemyBlood = 0;
        }
        else if(other.tag == "bullet")//敌机碰到了子弹
        {
            
            //掉血
            enemyBlood -= 20;
            Destroy(other.gameObject);

            
            
        }
        else if(other.tag == "ThunderFireLight"){//碰到了其他东西
            enemyBlood -= 50;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(other.tag == "ThunderFireLight"){//碰到了激光炮
            enemyBlood -= 50;
        }
    }
}
