using UnityEngine;
using System.Collections;
using System;

public class Pause : MonoBehaviour {

	public bool pause =false;
	GUITexture pauseGUI;
	public DateTime whenPaused;
	public DateTime whenResrumed;
	public bool isPaused=false;
	GameObject spawn;
	Spawn spawnScript;
	public bool gameEnded=false;

	void Start()
	{
		spawn = GameObject.Find ("SpawnPoint");
		spawnScript= (Spawn) spawn.GetComponent(typeof(Spawn));
	}
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

	public void resetWhen()
	{
		whenPaused=new DateTime();
		whenResrumed=new DateTime();
		
	}
	
	public void OnMouseDown(){
		if(pause==true && !gameEnded){
			pause = false;
				
			}
			else {
				pause = true;
			} if(pause == true) {
				Time.timeScale = 0;
				if (spawnScript.waveReleased!=0) whenPaused=DateTime.Now;
				isPaused=true;
				
				
			}
			else {
				Time.timeScale = 1;
			if (spawnScript.waveReleased!=0) whenResrumed=DateTime.Now;
				isPaused=false;
				
			}

	}

}
