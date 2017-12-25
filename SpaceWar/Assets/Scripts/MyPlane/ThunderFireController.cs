using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderFireController : MonoBehaviour {

    //爆炸效果
    public GameObject explode;
    private float offset = 15f;

    //用于存储正在发生碰撞的碰撞体
    private Collider collider;

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, 6);
        transform.localScale = new Vector3(0.2f, offset, 0.01f);
    }

    // Update is called once per frame
    void Update()
    {
        if (collider == null)
        {
            offset = 15f;
        }
        if (GameObject.Find("firePoint3") != null)
        {
            transform.position = GameObject.Find("firePoint3").transform.position + new Vector3(0, offset/2, 0);
        }
       
    }

   

    void OnTriggerStay(Collider others)
    {
        //碰到的是敌人
        if (others.tag == "Enemy")
        {
            Instantiate(explode, others.transform.position, Quaternion.identity);
            if (GameObject.Find("firePoint3") != null)
            {
                offset = others.transform.position.y - GameObject.Find("firePoint3").transform.position.y;
            }
            //存储正在发生碰撞的碰撞体
            transform.localScale = new Vector3(0.2f, offset, 0.01f);
            collider = others;
        }

        //碰到的是小boss
        if (others.tag == "LittleBoss")
        {
            Instantiate(explode, others.transform.position, Quaternion.identity);
            if (GameObject.Find("firePoint3") != null)
            {
                offset = others.transform.position.y - GameObject.Find("firePoint3").transform.position.y;
            }
            transform.localScale = new Vector3(0.2f, offset, 0.01f);
            //存储正在发生碰撞的碰撞体
            collider = others;
        }

        //碰到的是大boss
        if (others.name == "BigBoss")
        {
            Instantiate(explode, others.transform.position, Quaternion.identity);
            if (GameObject.Find("firePoint3") != null)
            {
                offset = others.transform.position.y - GameObject.Find("firePoint3").transform.position.y;
            }
            transform.localScale = new Vector3(0.2f, offset, 0.01f);
            collider = others;
        }
    }

    void OnTriggerExit(Collider others)
    {
        //激光离开物体后，还原为原来长度
            offset = 15f;
            transform.localScale = new Vector3(0.2f, offset, 0.01f);
    }

    //void Change()
    //{
    //    offset = 15f;
    //    transform.localScale = new Vector3(0.2f, offset, 0.01f);
    //}

}
