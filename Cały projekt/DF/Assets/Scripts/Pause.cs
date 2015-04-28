using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame

	bool pause =false;
	GUITexture pauseGUI;
	

	void Update(){

		if(Input.GetMouseButtonDown(0)) {
			if(pause==true){
				pause = false;

			}
			else {
				pause = true;
			} if(pause == true) {
				Time.timeScale = 0;

			}
			else {
				Time.timeScale = 1;
				
			}
		}
	}
}
