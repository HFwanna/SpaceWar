using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaneControl : MonoBehaviour {
    //子弹预设体
    public GameObject BulletPrefab;
    //特殊炸弹
    public GameObject SpecialBullet;
    private int SBNumber = 3;

    //三个发射点
    public Transform firePoint1;
    public Transform firePoint2;
    public Transform firePoint3;
    public GameObject plane;
    
    //统计按下开炮键的时间
    private float time;


    //飞机本身生命值
    public int number = 3;

    //雷电开关
    private int ThunderSwitch = 0;
    //雷电炮弹
    public GameObject ThunderLight;
    //防御罩
    public GameObject Protecter;

    //飞机的碰撞体
    private Collider collider;

	// Use this for initialization
	void Start () {
        collider = transform.GetComponent<CapsuleCollider>();
	}
	
	// Update is called once per frame
	void Update () {
        
		//WSAD控制飞机飞行，控制飞机移动范围
        if (transform.position.x >= -4.4)
        {
            if (Input.GetKey(KeyCode.A)) {
                    transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * 6);
            }
        }

        if (transform.position.x <= 4.4)
        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * 6);
            }
        }

         if (transform.position.y <= 6.8) 
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * 6);
            }

           
        }

        if (transform.position.y >= -6.8) 
        {
             if (Input.GetKey(KeyCode.S))
             {
                 transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * 6);
             }
        }
        //雷电开关关闭
        if (GameObject.Find("FireLight1") == null)
        {
            ThunderSwitch = 0;
        }

        //空格发射三个子弹
        if (Input.GetKey(KeyCode.Space) && ThunderSwitch == 0)
        {
            
            //控制子弹射出频率
            time += Time.deltaTime;
            if (time > 0.2f)
            {
                time = 0;
                GetComponent<AudioSource>().Play();
                Instantiate(BulletPrefab, firePoint1.transform.position, Quaternion.identity);
                Instantiate(BulletPrefab, firePoint2.transform.position, Quaternion.identity);
                Instantiate(BulletPrefab, firePoint3.transform.position, Quaternion.identity);
            }
        }
        //要保证按下按键瞬间肯定有子弹射出
        if (Input.GetKeyDown(KeyCode.Space))
        {
                GetComponent<AudioSource>().Play();
                Instantiate(BulletPrefab, firePoint1.transform.position, Quaternion.identity);
                Instantiate(BulletPrefab, firePoint2.transform.position, Quaternion.identity);
                Instantiate(BulletPrefab, firePoint3.transform.position, Quaternion.identity);
        }
        //保证按键起来是把time时间清零
        if (Input.GetKeyUp(KeyCode.Space))
        {
            time = 0;
        }

        //玩家血量小于等于0，玩家死亡
        if(GameObject.Find("GameController").GetComponent<AddScore>().BloodNumber<=0)
        {
            //if number <=0
            Destroy(gameObject);
        }

        //B键发射炸弹清屏
        if (Input.GetKeyDown(KeyCode.B)&&SBNumber>0)
        {
            SBNumber--;
            GameObject.Find("GameController").GetComponent<AddScore>().SBNumber--;
            GetComponent<AudioSource>().Play();
            Instantiate(SpecialBullet, firePoint3.transform.position, Quaternion.identity);
        }
	}

    void OnTriggerEnter(Collider other)
    { 
        //碰到了敌机就掉血
        if (other.tag == "Enemy") { 
            number--;
            GameObject.Find("GameController").GetComponent<AddScore>().BloodNumber--;
        }

        //碰到了道具
        if (other.name == "AddBloodItem")
        {
            //道具消失
            Destroy(other.gameObject);
            //生命+1
            if (GameObject.Find("GameController").GetComponent<AddScore>().BloodNumber<3)
            {
                GameObject.Find("GameController").GetComponent<AddScore>().BloodNumber++;
            }

        }

        if (other.name == "Power")
        {
            //道具消失
            Destroy(other.gameObject);
            //雷电开关开启
            ThunderSwitch = 1;
            //发射雷电
            Instantiate(ThunderLight,firePoint3.transform.position,Quaternion.identity);

        }

        if (other.name == "SPBullet")
        {
            //道具消失
            Destroy(other.gameObject);
            //增加核弹量
            if (GameObject.Find("GameController").GetComponent<AddScore>().SBNumber < 3)
            {
                GameObject.Find("GameController").GetComponent<AddScore>().SBNumber++;
            }

        }

        if (other.name == "Protect")
        {
            //道具消失
            Destroy(other.gameObject);
            //防御罩开启
            Instantiate(Protecter, plane.transform.position, Protecter.transform.rotation);
            collider.enabled = false;

        }

    }
}
