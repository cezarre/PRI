using UnityEngine;
using System.Collections;

public class Help : MonoBehaviour {

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            Application.LoadLevel("Menu");
        }
	       if (Input.GetKeyDown("backspace"))
        {
            Application.LoadLevel("Menu");
        }
    }

    public void GoToTheMenu()
    {
        Application.LoadLevel("Menu");
    }
}
