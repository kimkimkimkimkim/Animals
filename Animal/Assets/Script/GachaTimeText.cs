using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GachaTimeText : MonoBehaviour {

	private GameObject parentButton;
	private int num; //自分が何番目のガチャのテキストなのか

	private DateTime bornTime; //生まれる時刻

	private void Start(){
		parentButton = transform.parent.gameObject;
		num = parentButton.GetComponent<ClickGachaButton>().num;
		if(PlayerPrefs.GetString("gacha"+num+"Time") != "null" && PlayerPrefs.GetString("gacha"+num+"Time") != "finish"){
			bornTime = DateTime.FromBinary(System.Convert.ToInt64(PlayerPrefs.GetString("gacha"+num+"Time")));
		}
	}

	private void Update(){
		if(bornTime == null)return;
		if(PlayerPrefs.GetString("gacha"+num+"Time") == "finish"){
			GetComponent<Text>().text = "孵化完了";
			return;
		}

		DateTime now = DateTime.Now;
		TimeSpan diff = bornTime - now;
		if(diff.Seconds >= 0){
			GetComponent<Text>().text = diff.Hours.ToString("D2") + ":" + diff.Minutes.ToString("D2") + 
				":" + diff.Seconds.ToString("D2");
		}else{
			//生まれる時間をすぎた
			GetComponent<Text>().text = "孵化完了";
			PlayerPrefs.SetString("gacha"+num+"Time","finish"); //孵化完了であることをPlayerPrefsに保存
		}

	}



}
