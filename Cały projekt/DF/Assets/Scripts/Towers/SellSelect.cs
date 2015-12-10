using UnityEngine;
using System.Collections;

public class SellSelect : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		
		int t = transform.parent.parent.GetComponent<Towers> ().TowerType;
		if (t == 1 || t == 2 || t == 3) {
			transform.parent.parent.gameObject.GetComponent<Towers> ().SellTower();
		}
		
	}
}
