using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRing : MonoBehaviour {

	public GameObject ringPrefab;

	private float time = 0;

	private int numRing = 3; //1セットで出す波の数
	private int count = 0; //波の数のカウンター
	private float ringSpan = 0.8f; //１セット内の波の間隔
	private float setSpan = 1.4f; //セット間の間隔

	private void FixedUpdate(){
		time += Time.deltaTime;

		//セットが終わってない
		if(count < numRing){
			if(time >= ringSpan){
				_CreateRing();
				time = 0;
				count++;
			}
		}else{
			//１セットの波を全部出した
			if(time >= setSpan){
				_CreateRing();
				time = 0;
				count = 1;
			}

		}
	}

	
	private void _CreateRing(){
		GameObject ring = (GameObject)Instantiate(ringPrefab);
		ring.transform.SetParent(this.transform,false);
		ring.GetComponent<RectTransform>().localPosition = new Vector3(0,-90,0);
	}
}
