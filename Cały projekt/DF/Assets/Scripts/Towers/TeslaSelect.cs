using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TeslaSelect : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		int t = transform.parent.parent.GetComponent<Towers> ().TowerType;
		if (t == 0 || t == 1) {
			transform.parent.parent.gameObject.GetComponent<Towers> ().BuildTesla ();
		}

	}

}
