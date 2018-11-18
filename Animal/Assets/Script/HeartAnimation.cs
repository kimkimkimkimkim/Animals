using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartAnimation : MonoBehaviour {

	private float upDis = 0.4f; //上がる距離
	private float scaleMin = 0.4f; //一番小さい時のスケール
	private float scaleMax = 0.6f; //一番大きい時のスケール

	private float timeAnimation = 0.5f; //アニメーション全体の時間

	private RectTransform rectHeart; //ハートのRectTransform

	// Use this for initialization
	void Start () {
		rectHeart = this.GetComponent<RectTransform>();
		AnimationAlfa();
		AnimationMove();
		AnimationScale();
		Invoke("_Destroy",timeAnimation);
	}

	//アルファ値を変更
	private void AnimationAlfa(){
		
	}

	//上に上がる動き
	private void AnimationMove(){
		iTween.MoveBy(gameObject,iTween.Hash("y",upDis,"time",timeAnimation,"EaseType",iTween.EaseType.linear));
	}

	//大きさを変える
	private void AnimationScale(){
		iTween.ValueTo(gameObject,iTween.Hash("from",scaleMin,"to",scaleMax,
			"onupdate","UpdateScale","onupdatetarget",gameObject,"time",timeAnimation/2,
			"oncomplete","CompleteScale","oncompletetarget",gameObject));
	}

	private void UpdateScale(float s){
		rectHeart.localScale = new Vector3(s,s,s);
	}

	private void CompleteScale(){
		iTween.ValueTo(gameObject,iTween.Hash("from",scaleMax,"to",scaleMin,
			"onupdate","UpdateScale","onupdatetarget",gameObject,"time",timeAnimation/2));
	}

	private void _Destroy(){
		Destroy(this.gameObject);
	}
}
