using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///	タップした時にハート出したり、ハートゲットしたり
/// <summary>
public class TapManager : MonoBehaviour {

	public GameObject canvasAnimation; //ハートを表示するキャンバス
	public GameObject heartPrefab; //ハートプレハブ

	public AudioClip tapSE; //タップした時のSE

	//ハートの出現位置のブレ幅(2deltaX × 2deltaYの正方形の中にランダムで出現)
	private float deltaX = 80;
	private float deltaY = 80;
	//一回のタップで出現するハートの数
	//private int numHeart = 3;

	private AudioSource audioSource; //オーディオソース

	private void Start(){
		audioSource = this.gameObject.GetComponent<AudioSource>();
	}

	private void Update(){
		if(PlayerPrefs.GetInt("canMove") == 0)return;
		//クリックを検知
		if(Input.GetMouseButtonDown(0)){
			ShowHeart();
			audioSource.PlayOneShot(tapSE); //tapSEを流す
		}
	}

	//ハートの表示
	private void ShowHeart(){
		Vector3 pos = Input.mousePosition;
		StartCoroutine(DelayShowHeart(0f,pos));
		StartCoroutine(DelayShowHeart(0.05f,pos));
		StartCoroutine(DelayShowHeart(0.1f,pos));
	}

	//ハートの表示（遅延）
	IEnumerator DelayShowHeart(float delay, Vector3 pos) {
		//delay秒待つ
		yield return new WaitForSeconds(delay);
		/*処理*/
		pos.z = 0;
		RectTransform canvasUIRect = canvasAnimation.GetComponent<RectTransform>();
		Vector3 viewportPos = Camera.main.ScreenToViewportPoint(pos);

		Vector2 heartPos = new Vector2(
			((viewportPos .x * canvasUIRect.sizeDelta.x) - (canvasUIRect.sizeDelta.x * 0.5f)),
			((viewportPos .y * canvasUIRect.sizeDelta.y) - (canvasUIRect.sizeDelta.y * 0.5f)));
		heartPos = new Vector2(heartPos.x + Random.Range(-1*deltaX,deltaX),heartPos.y + Random.Range(-1*deltaY,deltaY));
		
		GameObject heart = (GameObject)Instantiate(heartPrefab);
		heart.transform.SetParent(canvasAnimation.transform, false);
		heart.GetComponent<RectTransform>().localPosition = heartPos;
	}
}
