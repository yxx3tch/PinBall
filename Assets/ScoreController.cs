using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {
	private GameObject scoreText;
	//表示用のスコア
	private int score = 0;
	//各オブジェクトに衝突した時に加算されるスコア
	private int smallStarScore = 10;
	private int largeStarScore = 20;
	private int smallCloudScore = 30;
	private int largeCloudScore = 40;
	// Use this for initialization
	void Start () {
		//開始時のスコアを画面に表示
		this.scoreText = GameObject.Find("ScoreText");
		this.scoreText.GetComponent<Text>().text = "Score : " + score;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//衝突時に呼ばれる関数
	void OnCollisionEnter(Collision other) {
		//衝突オブジェクトに応じて設定したスコアを加算
		if (other.gameObject.tag == "SmallStarTag") {
				score += smallStarScore;
		}else if (other.gameObject.tag == "LargeStarTag") {
				score += largeStarScore;
		}else if(other.gameObject.tag == "SmallCloudTag") {
				score += smallCloudScore;
		}else if(other.gameObject.tag == "LargeCloudTag"){
				score += largeCloudScore;
		}
		//加算されたスコアを画面に表示
		this.scoreText.GetComponent<Text>().text = "Score : " + score;
	}
}
