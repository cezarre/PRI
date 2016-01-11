using UnityEngine;
using System.Collections;

public class SellSelect : MonoBehaviour {

    public int Price;

    // Use this for initialization
    void Start () {
        Price = 50;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		
		int t = transform.parent.parent.GetComponent<Towers> ().TowerType;
		if (t == 1 || t == 2 || t == 3) {
			transform.parent.parent.gameObject.GetComponent<Towers> ().SellTower();

            transform.parent.FindChild("Tower1").gameObject.GetComponent<TeslaSelect>().RestartPrice();
            transform.parent.FindChild("Tower2").gameObject.GetComponent<AlchSelect>().RestartPrice();
            transform.parent.FindChild("Tower3").gameObject.GetComponent<EmmiterSelect>().RestartPrice();
        }
		
	}
}
