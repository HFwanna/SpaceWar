using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {
    //开关变量
    private int switchh = 1;

    //子弹预设体
    public GameObject bullet;

    //激光炮
    public GameObject fireLight;
    public GameObject fireLightPoint;
    //开火点第一排
    public GameObject fire1;
    public GameObject fire5;
    //开火点第二排
    public GameObject fire6;
    public GameObject fire2;
    //开火点第三排
    public GameObject fire7;
    public GameObject fire3;
    //开火点第四排
    public GameObject fire8;
    public GameObject fire4;
    //游戏开始时间
    private float timer = 0;
    private float timer_j = 0;
    



	// Use this for initialization
	void Start () {

        
        

	}
	
	// Update is called once per frame
	void Update () {
        
     
	}

    void FixedUpdate()
    {
        //到底指定高度后不再向前移动
        if (transform.position.y >= 5.89)
        {
            transform.Translate(new Vector3(0, 0, -1) * Time.deltaTime * 5);
        }
        else
        {
            //判断位置在到达左边后关闭开关变量
            if (transform.position.x >= -3.2 && switchh == 1)
            {
                transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * 6);

                if (transform.position.x <= -3.2)
                {
                    
                    switchh = 0;
                    
                }

            }
            //当位置在最右边时打开向左移动的开关变量
            else if (transform.position.x >= 3.2)
            {
                switchh = 1;
            }
            //到达左边关闭变量后向右移动
            else
            {
                transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * 6);
            }
        

            timer += Time.deltaTime;
            timer_j += Time.deltaTime;

            //普通炮弹1秒一排
            if (timer > 1)
            {
                Instantiate(bullet, fire1.transform.position, Quaternion.identity);
                Instantiate(bullet, fire5.transform.position, Quaternion.identity);

                Instantiate(bullet, fire2.transform.position, Quaternion.identity);
                Instantiate(bullet, fire6.transform.position, Quaternion.identity);


                Instantiate(bullet, fire3.transform.position, Quaternion.identity);
                Instantiate(bullet, fire7.transform.position, Quaternion.identity);



                Instantiate(bullet, fire4.transform.position, Quaternion.identity);
                Instantiate(bullet, fire8.transform.position, Quaternion.identity);
                timer = 0;
            }

            //激光炮3秒一次
            if (timer_j > 3)
            {
                Instantiate(fireLight, new Vector3(fireLightPoint.transform.position.x, fireLightPoint.transform.position.y, fireLightPoint.transform.position.z), Quaternion.identity);
                timer_j = 0;
            }
        }
  
    }
}
