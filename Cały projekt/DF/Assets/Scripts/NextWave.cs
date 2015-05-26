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
		//Spawn s = spawnPoint.GetComponent<Spawn>();
		//s.isClickedNextWaved ();
		//spawnPoint.isClickedNextWaved ();
		try {
		spawnPoint.isClickedNextWaved ();
		}
		catch(System.NullReferenceException e) {
			print ("ERROR: " + e.Message);
		}
	}
}
