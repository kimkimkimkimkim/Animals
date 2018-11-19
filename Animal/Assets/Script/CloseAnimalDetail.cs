using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseAnimalDetail : MonoBehaviour {

	public void OnClick(){
		this.transform.parent.parent.gameObject.SetActive(false);
	}
}
