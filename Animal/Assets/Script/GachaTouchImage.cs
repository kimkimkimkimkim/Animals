using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class GachaTouchImage : MonoBehaviour {

	public GameObject animalPrefab;
	public GameObject animalField;
	public GameObject plane;

	private GameObject button;
	private int num;

	private void Start(){
		button = transform.parent.gameObject;
		num = button.GetComponent<ClickGachaButton>().num;
	}

	public void OnClick(){
		if(PlayerPrefs.GetString("gacha"+num+"Time") == "finish"){
			//初期状態に戻す
			PlayerPrefs.SetString("gacha"+num+"Time","null");
			button.GetComponent<Image>().enabled = true;
			button.transform.Find("Text").gameObject.SetActive(false);
			Destroy(button.transform.Find("GemPrefab(Clone)").gameObject);
			gameObject.SetActive(false);

			//動物出現
			/*
			GameObject animal = (GameObject)Instantiate(animalPrefab);
			animal.transform.SetParent(animalField.transform,false);
			*/
			animalPrefab.SetActive(true);
		}else{
			//ガチャ時間短縮
			
		}
	}
}
