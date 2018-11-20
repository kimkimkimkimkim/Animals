using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemAnimation : MonoBehaviour {

	private float timeAnimation = 1.5f; //アニメーション全体の時間
	private float floatDis = 15f; //縦揺れの距離
	private float firstY; //最初のy座標
	private Vector3 firstPos; //最初の座標

	// Use this for initialization
	void Start () {
		firstPos = GetComponent<Transform>().localPosition;
		firstY = firstPos.y;
		MoveDown();
	}

	private void MoveUp(){
		iTween.ValueTo(gameObject,iTween.Hash("from",firstY-floatDis,"to",firstY,"time",timeAnimation/2,
			"EaseType",iTween.EaseType.easeOutQuad,"oncomplete","MoveDown","oncompletetarget",gameObject,
			"onupdate","UpdatePos","onupdatetarget",gameObject,"isLocal",true));
	}

	private void MoveDown(){
		iTween.ValueTo(gameObject,iTween.Hash("from",firstY,"to",firstY-floatDis,"time",timeAnimation/2,
			"EaseType",iTween.EaseType.easeInQuad,"oncomplete","MoveUp","oncompletetarget",gameObject,
			"onupdate","UpdatePos","onupdatetarget",gameObject,"isLocal",true));
	}

	private void UpdatePos(float y){
		GetComponent<Transform>().localPosition = new Vector3(firstPos.x,y,firstPos.z);
	}
}
