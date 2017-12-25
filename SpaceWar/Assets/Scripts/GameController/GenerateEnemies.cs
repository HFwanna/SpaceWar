using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour {
    //boss产生小飞机
    public GameObject smallBoss;
    //敌机预设体
    public GameObject enemyPrefab;
    public GameObject boss;
    //记录时间
    float timer = 0;
    float timer2 = 0;

    private int switchh=1;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        timer2 += Time.deltaTime;

        //疫苗两架飞机
        if (timer >= 0.5f)
        {
            timer = 0;
            //随机敌机位置
            float x = Random.Range(-4.5f, 5f);
            //创建敌机
            Instantiate(enemyPrefab, new Vector3(x, 7, -0.5f), Quaternion.identity);
        }

        //产生Boss
        if (timer2 >= 5 && switchh == 1)
        {
            //创建boss
            switchh = 0;
            Instantiate(boss, new Vector3(0, 9.05f, -0.5f), this.transform.rotation);
        }

        //boss出来后拥有群机突袭技能
        if (timer2 >= 10 && switchh == 0)
        {
            //time大于10boss已经存在，这个时候看看boss是不是被消灭了，如果是，把开关打开，继续产生boss
            if (GameObject.Find("Enemy2") == null)
            {
                switchh = 1;
                timer2 = 0;
            }else
            {
                //产生5个飞机
                Instantiate(smallBoss, new Vector3(0, 4.27f, -0.5f), this.transform.rotation);
                Instantiate(smallBoss, new Vector3(-2.02f, 4.91f, -0.5f), this.transform.rotation);
                Instantiate(smallBoss, new Vector3(2.02f, 4.91f, -0.5f), this.transform.rotation);
                Instantiate(smallBoss, new Vector3(3.62f, 5.71f, -0.5f), this.transform.rotation);
                Instantiate(smallBoss, new Vector3(-3.62f, 5.71f, -0.5f), this.transform.rotation);
                timer2 = 5;
            }

        }
	}
}
