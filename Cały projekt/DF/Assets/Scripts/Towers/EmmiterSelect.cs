using UnityEngine;
using System.Collections;

public class EmmiterSelect : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		int t = transform.parent.parent.GetComponent<Towers> ().TowerType;
        int t_level = transform.parent.parent.GetComponent<Towers>().t_level;
        if (t == 0 || t == 3) {
            if (t_level < 3)
            {
                transform.parent.parent.gameObject.GetComponent<Towers>().BuildWait();
                transform.parent.parent.GetComponent<Towers>().TowerType = 3;
            }
            
            //transform.parent.parent.gameObject.GetComponent<Towers> ().BuildEmitter ();
        }
		
	}
}
