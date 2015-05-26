using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("escape")) {//When a key is pressed down it see if it was the escape key if it was it will execute the code
			Application.Quit();
		}
		if(Input.GetKeyDown("backspace")) {//When a key is pressed down it see if it was the escape key if it was it will execute the code
			Application.Quit();
		}
	}
}
