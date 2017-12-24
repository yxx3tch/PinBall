using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {
	private GameObject scoreText;
	private int score = 0;
	private int smallStarScore = 10;
	private int largeStarScore = 20;
	private int smallCloudScore = 30;
	private int largeCloudScore = 40;
	// Use this for initialization
	void Start () {
		this.scoreText = GameObject.Find("ScoreText");
		this.scoreText.GetComponent<Text>().text = "Score : " + score;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//衝突時に呼ばれる関数
	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "SmallStarTag") {
				score += smallStarScore;
		}else if (other.gameObject.tag == "LargeStarTag") {
				score += largeStarScore;
		}else if(other.gameObject.tag == "SmallCloudTag") {
				score += smallCloudScore;
		}else if(other.gameObject.tag == "LargeCloudTag"){
				score += largeCloudScore;
		}
		this.scoreText.GetComponent<Text>().text = "Score : " + score;
	}
}
