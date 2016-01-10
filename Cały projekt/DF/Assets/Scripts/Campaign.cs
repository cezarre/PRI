using UnityEngine;
using System.Collections;

public class Campaign : MonoBehaviour {
      
    GameObject Level_2, Level_3, Level_4, Level_5, Final_Level;

    // Use this for initialization
    void Start () {
        Level_2 = GameObject.Find("Level 2");
        Level_3 = GameObject.Find("Level 3");
        Level_4 = GameObject.Find("Level 4");
        Level_5 = GameObject.Find("Level 5");
        Final_Level = GameObject.Find("Final Level");

        Level_2.SetActive(false);
        Level_3.SetActive(false);
        Level_4.SetActive(false);
        Level_5.SetActive(false);
        Final_Level.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
		if (PlayerPrefs.GetInt ("PlayerProgress") == 2)
			Level_2.SetActive (true);
		else if (PlayerPrefs.GetInt ("PlayerProgress") == 3) {
			Level_2.SetActive (true);
			Level_3.SetActive (true);
		}
		else if (PlayerPrefs.GetInt("PlayerProgress") == 4)
		{
			Level_2.SetActive(true);
			Level_3.SetActive(true);
            Level_4.SetActive(true);
		}
		else if (PlayerPrefs.GetInt("PlayerProgress") == 5) {
			Level_2.SetActive(true);
			Level_3.SetActive(true);
			Level_4.SetActive(true);
            Level_5.SetActive(true);
		}
		else if (PlayerPrefs.GetInt("PlayerProgress") == 6) {
			Level_2.SetActive(true);
			Level_3.SetActive(true);
			Level_4.SetActive(true);
			Level_5.SetActive(true);
            Final_Level.SetActive(true);
		}

        if (Input.GetKeyDown("escape"))
        {
            Menu.isPlaying = true;
            Application.LoadLevel("Menu");
        }

        if (Input.GetKeyDown("backspace"))
        {
            Menu.isPlaying = true;
            Application.LoadLevel("Menu");
        }
    }

    public void LoadLevel_1()
    {
        Application.LoadLevel("Level 1");
    }
    public void LoadLevel_2()
    {
        Application.LoadLevel("Level 2");
    }
    public void LoadLevel_3()
    {
        Application.LoadLevel("Level 3");
    }
    public void LoadLevel_4()
    {
        Application.LoadLevel("Level 4");
    }
    public void LoadLevel_5()
    {
        Application.LoadLevel("Level 5");
    }
    public void LoadFinal_Level()
    {
        Application.LoadLevel("Final Level");
    }
}
