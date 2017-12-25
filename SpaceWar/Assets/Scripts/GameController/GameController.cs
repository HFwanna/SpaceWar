using System.Collections;

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    //选项按钮
    public Button reStartButton;
    public Button quitButton;
    public Text GameOver;

    //延迟暂停
    private float pauseTime = 0;

	// Use this for initialization
	void Start () {
        //重新开始让时间继续
        Time.timeScale = 1;
        //游戏速度加快3倍
        //Time.timeScale = 3;
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("GameController").GetComponent<AddScore>().BloodNumber <= 0)
        {
            pauseTime += Time.deltaTime;
            if (pauseTime >= 0.4f)
            {
                reStartButton.gameObject.SetActive(true);
                quitButton.gameObject.SetActive(true);
                GameOver.gameObject.SetActive(true);

                //游戏暂停
                Time.timeScale = 0;
            }
        }


	}

    //重新开始游戏的方法
    public void ReStratGame()
    {
        //print("restart");
        
        SceneManager.LoadScene(0);
    }

    //推出游戏的方法
    public void QuitGame()
    {
        //print("quit");
        Application.Quit();
    }
}
