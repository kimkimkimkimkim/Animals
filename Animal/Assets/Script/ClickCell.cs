using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickCell : MonoBehaviour {

	private GameObject boxView; //ボックスビュー
	private GameObject animalDetail; //詳細画面

	private void Start(){
		boxView = transform.parent.parent.parent.parent.gameObject;
		animalDetail = boxView.transform.GetChild(1).gameObject;
	}

	public void OnClick(){
		animalDetail.SetActive(true);
	}
}
