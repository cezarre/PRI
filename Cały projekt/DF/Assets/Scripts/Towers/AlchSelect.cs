using UnityEngine;
using System.Collections;

public class AlchSelect : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		
		transform.parent.parent.gameObject.GetComponent<Towers>().BuildAlch();
		
		
	}
}
