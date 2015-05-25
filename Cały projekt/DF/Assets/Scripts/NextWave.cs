using UnityEngine;
using System.Collections;

public class NextWave : MonoBehaviour {
	public Spawn spawnPoint;
	// Use this for initialization
	void Start () {
		//spawnPoint = gameObject.GetComponent<Spawn>();



	
	}
	
	// Update is called once per frame
	void Update () {

	
	}
	public void OnMouseDown(){
		//spawnPoint = gameObject.GetComponent<Spawn>();
		
		spawnPoint.isClickedNextWaved ();


	}
}
