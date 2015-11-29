using UnityEngine;
using System.Collections;

public class Soundtrack : MonoBehaviour {

    public AudioSource sound;

    GameObject unmute;
    public GameObject mute;

    // Use this for initialization
    void Start()
    {
        unmute = GameObject.Find("Unmute");
        mute = GameObject.Find("Mute");

        if (Menu.isPlaying)
        {
            unmute.SetActive(true);
            mute.SetActive(false);
            sound.Play();
        }
        else
        {
            unmute.SetActive(false);
            mute.SetActive(true);
        }
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void SoundOnOff()
    {
        if (!Menu.isPlaying)
        {
            if (!sound.isPlaying)
                sound.Play();
            else
                sound.UnPause();

            Menu.isPlaying = true;
        }
        else
        {
            sound.Pause();
            Menu.isPlaying = false;
        }
    }
}
