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

		int t = transform.parent.parent.GetComponent<Towers> ().TowerType;
		if (t == 0 || t == 2) {
			transform.parent.parent.gameObject.GetComponent<Towers> ().BuildAlch ();
		}
		
	}
}
