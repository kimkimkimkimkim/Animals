using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundCamera : MonoBehaviour {

	//回転の中心点
	public GameObject centerObj;
	private Vector3 centerPos;

	//直前のマウス座標と現在のマウス座標
	private Vector3 backPos;
	private Vector3 newPos;

	//縦方向の回転に必要なパラメーター
	private float vAngle = 0; //現在の回転角
	private float vAngleMin = -25f;
	private float vAngleMax = 17.8f;

	// Use this for initialization
	void Start () {
		centerPos = centerObj.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerPrefs.GetInt("canMove",1) == 0 || Input.touchCount >= 2)return;
		if(Input.GetMouseButtonDown(0)){
			backPos = Input.mousePosition;
			newPos = Input.mousePosition;
		}
		if(Input.GetMouseButton(0)){
			newPos = Input.mousePosition;

			float disX = (newPos.x - backPos.x)/5;
			float disY = (backPos.y - newPos.y)/10;

			if(disX != 0){
				this.transform.RotateAround(centerPos,new Vector3(0,1,0),disX);
			}
			if(disY != 0){
				//回転軸計算用
				Vector3 cameraPos1 = transform.position;
				Vector3 cameraPos2 = new Vector3(cameraPos1.x,cameraPos1.y + 1,cameraPos1.z);
				Vector3 rAxis = Vector3.Cross(cameraPos1-centerPos,cameraPos2-centerPos);

				vAngle += disY;
				if(disY > 0 && vAngle > vAngleMax){
					disY -=  vAngle - vAngleMax;
					vAngle = vAngleMax;
				}
				if(disY < 0 && vAngle < vAngleMin){
					disY += vAngleMin - vAngle;
					vAngle = vAngleMin;
				}
				this.transform.RotateAround(centerPos,rAxis,disY);
			}
			backPos = Input.mousePosition;
		}
	}
}
