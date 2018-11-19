using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxViewScrollContent : MonoBehaviour {

	public GameObject cellPrefab; //表示するセルのプレハブ

	private int horiNum = 5; //横に入るアイテムの数
	private float cellLen; //セルの一辺の長さ

	private int cellNum = 50; //セルの個数

	// Use this for initialization
	void Start () {
		cellLen = (GetComponent<RectTransform>().rect.width - 
			GetComponent<GridLayoutGroup>().spacing.x * (horiNum + 1))/(float)horiNum;
		GetComponent<GridLayoutGroup>().cellSize = new Vector2(cellLen,cellLen);

		for(int i=0;i<cellNum;i++){
			GameObject cell = (GameObject)Instantiate(cellPrefab);
			cell.transform.SetParent(this.transform,false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
