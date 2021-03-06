﻿using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

    public static bool isPlaying = true;

    // Use this for initialization
    public void Start () {
        ActiveContinoune();
    }

    // Update is called once per frame
    void Update()
    {
        print(PlayerPrefs.GetInt("PlayerProgress"));
    }

    public void LoadScene(){
        isPlaying = false;
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
        isPlaying = false;
        Application.LoadLevel("Campaign");
    }

    public void LoadHelp()
    {
        Application.LoadLevel("Help");
    }

    public void Quit(){
		Application.Quit ();
	}
}
