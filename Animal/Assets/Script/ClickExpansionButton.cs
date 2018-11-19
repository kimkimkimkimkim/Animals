using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickExpansionButton : MonoBehaviour {

	public GameObject island; //島
	public GameObject gachaArea; //ガチャエリア
	public GameObject boxView; //ボックス画面
	public GameObject expansionView; //拡張画面

	public void OnClick(){
		PlayerPrefs.SetInt("canMove",0);
		expansionView.SetActive(true);
		boxView.SetActive(false);
		gachaArea.SetActive(false);
		island.GetComponent<MoveIsland>().MoveUp();
	}
}
