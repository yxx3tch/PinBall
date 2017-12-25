using UnityEngine;
using System.Collections;

public class FripperController : MonoBehaviour {
        //HingiJointコンポーネントを入れる
        private HingeJoint myHingeJoint;

        //初期の傾き
        private float defaultAngle = 20;
        //弾いた時の傾き
        private float flickAngle = -20;

        // Use this for initialization
        void Start () {
                //HinjiJointコンポーネント取得
                this.myHingeJoint = GetComponent<HingeJoint>();

                //フリッパーの傾きを設定
                SetAngle(this.defaultAngle);
        }

        // Update is called once per frame
        void Update () {

                //左矢印キーを押した時左フリッパーを動かす
                if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag") {
                SetAngle (this.flickAngle);
                }
                //右矢印キーを押した時右フリッパーを動かす
                if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag") {
                SetAngle (this.flickAngle);
                }

                //矢印キー離された時フリッパーを元に戻す
                if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag") {
                SetAngle (this.defaultAngle);
                }
                if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag") {
                SetAngle (this.defaultAngle);
                }

                                
                //タッチされた時の処理
                if(Input.touchCount > 0){
                        //画面の左側をタッチした時フリッパーを動かす
                        if(Input.GetTouch(0).position.x < Screen.width / 2 && tag == "LeftFripperTag"){
                        SetAngle (this.flickAngle);
                        }
                        //画面の右側をタッチした時フリッパーを動かす
                        if(Input.GetTouch(0).position.x > Screen.width / 2 && tag == "RightFripperTag"){
                        SetAngle (this.flickAngle);
                        }
                        //画面から指を離した際にフリッパーを元に戻す
                        if(Input.GetTouch(0).phase == TouchPhase.Ended && tag == "LeftFripperTag"){
                        SetAngle (this.defaultAngle);
                        }
                        if(Input.GetTouch(0).phase == TouchPhase.Ended && tag == "RightFripperTag"){
                        SetAngle (this.defaultAngle);
                        }       
                }
        }

        //フリッパーの傾きを設定
        public void SetAngle (float angle){
                JointSpring jointSpr = this.myHingeJoint.spring;
                jointSpr.targetPosition = angle;
                this.myHingeJoint.spring = jointSpr;
        }
}