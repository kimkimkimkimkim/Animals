using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RingAnimation : MonoBehaviour {

	private float timeAnimation = 2.5f; //アニメーション全体の時間
	private float scaleMin = 0.5f; //一番小さい時のスケール
	private float scaleMax = 2f; //一番小さい時のスケール

	private float timeSwitchAlfa = 1.0f; //アルファ値が切り替わるタイミング
	private float alfaMin = 0.1f; 
	private float alfaMax = 0.7f;


	// Use this for initialization
	void Start () {
		AnimationScale();
		AnimationAlfa();
		Invoke("_Destroy",timeAnimation);
	}
	
	private void AnimationScale(){
		iTween.ValueTo(gameObject, iTween.Hash("from",scaleMin,"to",scaleMax,"time",timeAnimation,
			"onupdate","UpdateScale","onupdatetarget",gameObject));
	}

	private void UpdateScale(float s){
		this.transform.localScale = new Vector3(s,s,1);
	}

	private void AnimationAlfa(){
		iTween.ValueTo(gameObject, iTween.Hash("from",alfaMin,"to",alfaMax,"time",timeSwitchAlfa,
			"onupdate","UpdateAlfa","onupdatetarget",gameObject,
			"oncomplete","CompleteAlfa","oncompletetarget",gameObject));
	}

	private void UpdateAlfa(float a){
		Color c = this.GetComponent<Image>().color;
		this.GetComponent<Image>().color = new Color(c.r,c.g,c.b,a);
	}

	private void CompleteAlfa(){
		iTween.ValueTo(gameObject, iTween.Hash("from",alfaMax,"to",alfaMin,"time",timeAnimation - timeSwitchAlfa,
			"onupdate","UpdateAlfa","onupdatetarget",gameObject));
	}

	private void _Destroy(){
		Destroy(this.gameObject);
	}


}
