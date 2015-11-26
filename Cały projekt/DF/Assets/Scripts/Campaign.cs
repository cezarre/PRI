﻿using UnityEngine;
using System.Collections;

public class Campaign : MonoBehaviour {
    public static bool level2 = false;
    
    GameObject Level_2;

    // Use this for initialization
    void Start () {
        Level_2 = GameObject.Find("Level 2");
        Level_2.SetActive(false);
	}

    // Update is called once per frame
    void Update()
    {

        if (level2)
            Level_2.SetActive(true);

        if (Input.GetKeyDown("escape"))
            Application.LoadLevel("Menu");

        if (Input.GetKeyDown("backspace"))
            Application.LoadLevel("Menu");
    }

    public void LoadLevel_1()
    {
        Application.LoadLevel("Level 1");
    }

    public void LoadLevel_2()
    {
        Application.LoadLevel("Level 2");
    }
}
