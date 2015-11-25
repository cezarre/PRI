using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	// Use this for initialization
	public void Start () {

	}

	public void LoadScene(){
		Application.LoadLevel("campaign");
	}

	public void Quit(){
		Application.Quit ();
	}

	
	// Update is called once per frame
	void Update () {

	}
}
