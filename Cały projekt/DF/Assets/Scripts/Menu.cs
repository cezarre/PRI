using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	// Use this for initialization
	public void Start () {

	}

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadScene(){
		Application.LoadLevel("Campaign");
	}

	public void Quit(){
		Application.Quit ();
	}
}
