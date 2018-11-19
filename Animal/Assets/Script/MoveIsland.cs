using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveIsland : MonoBehaviour {

	private float upY = 3765;
	private float downY;

	private void Start(){
		downY = this.transform.localPosition.y;
	}

	public void MoveUp(){
		iTween.MoveTo(gameObject,iTween.Hash("y",upY,"isLocal",true));
	}

	public void MoveDown(){
		iTween.MoveTo(gameObject,iTween.Hash("y",downY,"isLocal",true));
	}
}
