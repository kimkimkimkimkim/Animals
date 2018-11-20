using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickGachaButton : MonoBehaviour {

	public int num; //何番目のガチャなのか

	public GameObject smokePrefab; //スモークプレハブ
	public GameObject gemPrefab; //宝石プレハブ

	public void OnClick(){
		//煙を生成
		GameObject smoke = (GameObject)Instantiate(smokePrefab);
		smoke.transform.SetParent(this.transform,false);
		smoke.GetComponent<Transform>().localPosition = new Vector3(0,-100,-100);

		//宝石を時間差で生成
		Invoke("ShowGem",1.0f);

		//ボタンを見えなくする
		GetComponent<Image>().enabled = false;
	}

	private void ShowGem(){
		GameObject gem = (GameObject)Instantiate(gemPrefab);
		gem.transform.SetParent(this.transform,false);
		gem.GetComponent<Transform>().localPosition = new Vector3(0,-30,0);
	}
}
