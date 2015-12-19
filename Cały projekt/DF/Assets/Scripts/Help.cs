using UnityEngine;
using System.Collections;

public class Help : MonoBehaviour {

	// Use this for initialization
	void Start () {
        ActiveContinue();
    }

    public void ActiveContinue()
    {
        if (PlayerPrefs.GetInt("PlayerProgress") > 1)
        {
            if (Menu.isMenuLoadedOnce)
            {
                Application.LoadLevel("Menu");
            }
        }
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyDown("escape"))
    //    {
    //        Application.LoadLevel("Menu");
    //    }

    //    if (Input.GetKeyDown("backspace"))
    //    {
    //        Application.LoadLevel("Menu");
    //    }
    //}

    public void GoToTheMenu()
    {
        Application.LoadLevel("Menu");
    }
}
