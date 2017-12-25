using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddScore : MonoBehaviour {
    //统计分数
    public int score = 0;
    //显示分数的文本框
    public Text scoreText;

    //核弹文本框
    public Text SBText;
    //核弹数量
    public int SBNumber = 3;

    //玩家生命数量
    public int BloodNumber = 3;
    //显示生命数量的文本
    public Text bloodText;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = score.ToString();
        bloodText.text = BloodNumber.ToString();
        SBText.text = SBNumber.ToString();
	}
}
