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

		transform.parent.parent.gameObject.GetComponent<Towers>().BuildTesla ();

		
	}
}
