using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	bool pause =false;
	GUITexture pauseGUI;

	void Update()
	{
		/*
		RaycastHit hitInfo = new RaycastHit();
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		
		// OnMouseDown
		if (Input.GetMouseButtonDown(0))
		{
			if (Physics.Raycast(ray, out hitInfo))
			{
				hitInfo.collider.SendMessage("OnMouseDown", SendMessageOptions.DontRequireReceiver);
				Debug.Log ("PAUZA");
				
			}
		}
		*/
	}
	
	public void OnMouseDown(){
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
