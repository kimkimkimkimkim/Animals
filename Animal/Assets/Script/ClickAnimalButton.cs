using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAnimalButton : MonoBehaviour {

	public GameObject view; //表示するView
	public GameObject island; //島
	public GameObject gachaArea; //ガチャエリア
	public GameObject expansionView; //拡張画面

	public void OnClick(){
		PlayerPrefs.SetInt("canMove",0);
		view.SetActive(true); //Viewの表示
		expansionView.SetActive(false);
		gachaArea.SetActive(false); //ガチャエリアの非表示
		island.GetComponent<MoveIsland>().MoveUp();
	}
}
