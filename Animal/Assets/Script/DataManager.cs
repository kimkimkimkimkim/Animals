using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour {

	/*
	 {
		 "canMove", int スワイプやピンチインアウトでカメラを移動できるかどうか
	 }
	 */
	void Start () {
		PlayerPrefs.SetInt("canMove",1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
