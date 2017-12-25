using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectEffective : MonoBehaviour {

    //获取mesh组件
    MeshRenderer mesh;

    //爆炸效果
    public GameObject explode;

    //时间限制
    private float time;

    //飞机的碰撞体
    private Collider collider;

    // Use this for initialization
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        collider = GameObject.Find("MyPlane").GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        mesh.material.mainTextureOffset += new Vector2(0, Time.deltaTime * -1.2f);
        if (GameObject.Find("Player")!=null)
        {
            transform.position = GameObject.Find("Player").transform.position;
        }
        time += Time.deltaTime;
        if (time > 7)
        {
            Destroy(gameObject);
            //恢复飞机碰撞体效果
            collider.enabled = true;
        }
    }

    void OnTriggerEnter(Collider others)
    {
        if (others.tag == "Enemy")
        {
            Destroy(others.gameObject);
            Instantiate(explode, others.transform.position, Quaternion.identity);
        }
        if (others.tag == "EnemiesBullet")
        {
            Destroy(others.gameObject);
            Instantiate(explode, others.transform.position, Quaternion.identity);
        }
        if (others.tag == "LittleBoss")
        {
            Destroy(others.gameObject);
            Instantiate(explode, others.transform.position, Quaternion.identity);
        }
        if (others.name == "BigBoss")
        {
            //找到其中一个碰撞体中的函数消去他的血量
            GameObject.Find("LeftCollider").GetComponent<BossCollider>().bossBlood -= 50;
            Instantiate(explode, others.transform.position, Quaternion.identity);
        }
        if (others.name == "BigBoss")
        {
            //找到其中一个碰撞体中的函数消去他的血量
            GameObject.Find("LeftCollider").GetComponent<BossCollider>().bossBlood -= 50;
            Instantiate(explode, others.transform.position, Quaternion.identity);
        }
        if (others.tag == "item")
        {
            //把防御罩碰到的物体值赋给PlaneControl的OnTriggerEnter方法来执行
            collider.SendMessage("OnTriggerEnter",others);
        }
    }
}
