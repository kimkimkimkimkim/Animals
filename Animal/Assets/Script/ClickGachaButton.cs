using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ClickGachaButton : MonoBehaviour {

	public int num; //何番目のガチャなのか

	public GameObject smokePrefab; //スモークプレハブ
	public GameObject gemPrefab; //宝石プレハブ

	private void Start(){
		//PlayerPrefs.SetString("gacha"+num+"Time","null");
		Debug.Log(PlayerPrefs.GetString("gacha"+num+"Time","null"));
		//孵化中の時
		if(PlayerPrefs.GetString("gacha"+num+"Time","null") != "null"){
			transform.Find("Text").gameObject.SetActive(true); //時間テキストを表示

			//宝石を表示
			GameObject gem = (GameObject)Instantiate(gemPrefab);
			gem.transform.SetParent(this.transform,false);
			gem.GetComponent<Transform>().localPosition = new Vector3(0,-30,0);

			//ImageTouchを表示
			transform.Find("ImageTouch").gameObject.SetActive(true);

			this.gameObject.GetComponent<Image>().enabled = false; //ボタンの画像を非表示
		}
	}

	public void OnClick(){
		if(PlayerPrefs.GetString("gacha"+num+"Time","null") != "null"){
			return;
		}
		//煙を生成
		GameObject smoke = (GameObject)Instantiate(smokePrefab);
		smoke.transform.SetParent(this.transform,false);
		smoke.GetComponent<Transform>().localPosition = new Vector3(0,-100,-100);

		//5.0秒後にsmokeをdestroy
		StartCoroutine(DelayMethod(5.0f, () =>
		{
			Destroy(smoke.gameObject);
			transform.Find("Text").gameObject.SetActive(true);
		}));

		//宝石を時間差で生成
		Invoke("ShowGem",1.0f);

		//ボタンを見えなくする
		GetComponent<Image>().enabled = false;
	}

	private void ShowGem(){
		GameObject gem = (GameObject)Instantiate(gemPrefab);
		gem.transform.SetParent(this.transform,false);
		gem.GetComponent<Transform>().localPosition = new Vector3(0,-30,0);

		//レア度を決定
		DateTime nowTime = DateTime.Now; //現在の時刻
		DateTime bornTime = nowTime.AddMinutes(5); //生まれる時刻
		PlayerPrefs.SetString("gacha" + num + "Time",bornTime.ToBinary().ToString()); //生まれる時刻をPlayerPrefsに保存
	}

	/// <summary>
	/// 渡された処理を指定時間後に実行する
	/// </summary>
	/// <param name="waitTime">遅延時間[ミリ秒]</param>
	/// <param name="action">実行したい処理</param>
	/// <returns></returns>
	private IEnumerator DelayMethod(float waitTime, Action action)
	{
		yield return new WaitForSeconds(waitTime);
		action();
	}
}
