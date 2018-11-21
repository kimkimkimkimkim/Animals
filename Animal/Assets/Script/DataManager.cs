using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour {

	/*
	 {
		 "canMove", int スワイプやピンチインアウトでカメラを移動できるかどうか
		 "gacha1Time", string 1番目のガチャの生まれる時刻 孵化完了なら"finish" ガチャできる状態なら"null"

	 }
	 */
	void Start () {
		PlayerPrefs.SetInt("canMove",1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
