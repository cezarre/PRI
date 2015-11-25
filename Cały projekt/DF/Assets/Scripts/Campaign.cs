using UnityEngine;
using System.Collections;

public class Campaign : MonoBehaviour {
    public static bool level2 = false;
    
    GameObject Level_2;

    // Use this for initialization
    void Start () {
        Level_2 = GameObject.Find("Level 2");
        Level_2.SetActive(false);
	}

    public void Level_1()
    {
        Time.timeScale = 1;
        Application.LoadLevel("exampleScene");
    }

    public void LoadLevel_2()
    {
        Time.timeScale = 1;
        Application.LoadLevel("exampleScene2");
    }
    
    // Update is called once per frame
    void Update () {
        //Debug.Log("OK");
        if (level2)
        {
            Level_2.SetActive(true);
        }

        if (Input.GetKeyDown("escape"))
        {//When a key is pressed down it see if it was the escape key if it was it will execute the code
            Application.LoadLevel("menu");
        }
        if (Input.GetKeyDown("backspace"))
        {//When a key is pressed down it see if it was the escape key if it was it will execute the code
            Application.LoadLevel("menu");
        }
    }
}
