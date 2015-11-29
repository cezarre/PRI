using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	// Use this for initialization
	public void Start () {
        ActiveContinoune();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadScene(){
        PlayerPrefs.SetInt("PlayerProgress", 1);
        Application.LoadLevel("Campaign");
	}

    public void ActiveContinoune()
    {
        GameObject resume = GameObject.Find("Resume");
        GameObject continoune = GameObject.Find("Continue");
        if (PlayerPrefs.GetInt("PlayerProgress") > 1)
        {
            continoune.SetActive(true);
            resume.SetActive(false);
        }
        else
        {
            resume.SetActive(true);
            continoune.SetActive(true);
        }

     }

    public void LoadContiunue()
    {

        Application.LoadLevel("Campaign");

    }

    public void Quit(){
		Application.Quit ();
	}
}
