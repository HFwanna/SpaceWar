using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBullet : MonoBehaviour {
    private float time;
    public GameObject explosion;
    public GameObject explosion1;
    public GameObject explosion2;
    private GameObject[] gos;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * 10);
        if (time >= 0.3f)
        {
            //核弹爆炸
            Destroy(gameObject);
            //产生爆炸，随机效果
            int r = Random.Range(0, 3);
            print(r);
            if (r == 0)
            {
                Instantiate(explosion);
            }
            else if (r == 10)
            {
                Instantiate(explosion1);
            }
            else
            {
                Instantiate(explosion2);
            }
            
            gos = GameObject.FindGameObjectsWithTag("Enemy");
            //消灭所有敌机
            for (int i = 0; i < gos.Length; i++)
            {
                Destroy(gos[i]);
                GameObject.Find("GameController").GetComponent<AddScore>().score += 10;
            }
            //消灭所有子弹
            gos = GameObject.FindGameObjectsWithTag("EnemiesBullet");
            for (int i = 0; i < gos.Length; i++)
            {
                Destroy(gos[i]);
            }
            //消灭所有littleboss
            gos = GameObject.FindGameObjectsWithTag("LittleBoss");
            for (int i = 0; i < gos.Length; i++)
            {
                Destroy(gos[i]);
            }
        }
        

	}
}
