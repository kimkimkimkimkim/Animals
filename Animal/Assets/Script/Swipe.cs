using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Swipe : MonoBehaviour {

	public GameObject mesh;

	public GameObject field; //回転させるオブジェクト

	//直前の座標
	private Vector3 backPos;
	private Vector3 newPos;

	//スピード
	private float speed = 0.3f;

	//初期値
	private float hori = 0;
	private float ver = 0;

	//限界値
	private float deltaVer = 0;
	private float verMin = -13f;
	private float verMax = 17.8f;

	//水平方向の回転軸
	private Vector3 axis;

	private void Start(){
		axis = field.transform.up;
	}
	
	// Update is called once per frame
	/*
	void Update () {
		if(Input.touchCount == 1){
			Touch t1 = Input.GetTouch(0);

			if(t1.phase == TouchPhase.Began){
				backPos = t1.position;
			}else if(t1.phase == TouchPhase.Moved){
				Vector3 newPos = t1.position;
				hori = (backPos.x - newPos.x)/100.0f;
				ver = (newPos.y - backPos.y)/100.0f;

				if(Mathf.Abs(hori) >= Mathf.Abs(ver)){
					field.transform.Rotate(field.transform.up,hori);
				}else{
					field.transform.Rotate(new Vector3(1,0,0),ver);
				}
				
			}
		}
	}
	*/
	void Update(){
		if(Input.GetMouseButtonDown(0)){
			backPos = Input.mousePosition;
		}
		if(Input.GetMouseButton(0)){
			newPos = Input.mousePosition;

			float disX = Mathf.Abs(newPos.x - backPos.x);
			float disY = Mathf.Abs(newPos.y - backPos.y);
			if(disX >= disY){
				if(newPos.x > backPos.x){
					field.transform.Rotate(new Vector3(0,1,0),-1 * speed);
				}else{
					field.transform.Rotate(new Vector3(0,1,0),speed);
				}
			}else{
				float ySpeed = speed/2;
				if(newPos.y > backPos.y){
					deltaVer += ySpeed;
					if(deltaVer < verMax){
						field.transform.Rotate(ySpeed,0,0,Space.World);
					}
				}else{
					deltaVer -= ySpeed;
					if(deltaVer > verMin){
						field.transform.Rotate(-1 * ySpeed,0,0,Space.World);
					}
				}
			}
		}
	}
}
