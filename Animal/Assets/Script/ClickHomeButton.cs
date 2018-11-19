using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHomeButton : MonoBehaviour {

	public GameObject island; //島
	public GameObject gachaArea; //ガチャエリア
	public GameObject boxView; //ボックス画面

	public void OnClick(){
		PlayerPrefs.SetInt("canMove",1); //動かせるように
		island.GetComponent<MoveIsland>().MoveDown();
		gachaArea.SetActive(true);
		boxView.SetActive(false);
	}
}
