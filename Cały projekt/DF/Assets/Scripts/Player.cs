using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Player : MonoBehaviour {
	public int hp;
	public int gold;
	public int numberOfEnemy;

	GameObject HPGameObject, GoldGameObject, Spawn;
    GameObject spawn, win, gameOver, retry, backToMenu, pause, bombAbility;

    Text HPText, GoldGameText;

    Spawn spawnScript;
	Pause pauseScript;

	// Use this for initialization
	void Start () {
		HPGameObject = GameObject.Find("Left Text");
		HPText = HPGameObject.GetComponent<Text>();

		GoldGameObject = GameObject.Find("Right Text");
		GoldGameText = GoldGameObject.GetComponent<Text> ();

		HPText.text = hp.ToString ();
		GoldGameText.text = gold.ToString () + "$";

		spawn = GameObject.Find ("SpawnPoint");
		spawnScript= (Spawn) spawn.GetComponent(typeof(Spawn));
		win= GameObject.Find("You Win");
		gameOver=GameObject.Find("Game Over");
		retry=GameObject.Find("Retry");
		backToMenu=GameObject.Find("BackMenu");
        bombAbility = GameObject.Find("BombAbility");

        win.SetActive (false);
		gameOver.SetActive(false);
		retry.SetActive (false);
		backToMenu.SetActive (false);

		pause = GameObject.Find ("Pause");
		pauseScript= (Pause) pause.GetComponent(typeof(Pause));
    }

    public bool first = true;

    // Update is called once per frame
    void Update () {
		if (first) numberOfEnemy = spawnScript.numberOfEnemy;
		first = false;
        //Debug.Log ("liczba wrogow: " + numberOfEnemy.ToString ());
       
      
        if (numberOfEnemy == 0 && hp > 0) {
            //win
            bombAbility.SetActive(false);
            win.SetActive(true);
			backToMenu.SetActive (true);
			Time.timeScale = 0;
			pauseScript.gameEnded=true;
            string[] levelName = Application.loadedLevelName.Split(' ');
            int level;
            Int32.TryParse(levelName[levelName.Length - 1], out level);
            if (level+1> PlayerPrefs.GetInt("PlayerProgress")) PlayerPrefs.SetInt("PlayerProgress", level+1);
		}
	}

	public void decresseHp(int howMuchLessHp)
	{
		if (hp - howMuchLessHp <= 0) {
			hp = 0;

			//gameover
			gameOver.SetActive(true);
			retry.SetActive(true);
			Time.timeScale = 0;
			pauseScript.gameEnded=true;
		} else
			hp = hp - howMuchLessHp;
			HPText.text = hp.ToString ();
	}
	public void addGold(int amountOfGold)
	{
		gold = gold + amountOfGold;
		GoldGameText.text = gold.ToString ()+ "$";
	}

	public void Retry(){
		pauseScript.gameEnded=false;
		first=true;
		Time.timeScale = 1;
		Application.LoadLevel(Application.loadedLevelName);
	}

	public void BackMenu(){
		pauseScript.gameEnded=false;
		first=true;
		Time.timeScale = 1;
		Application.LoadLevel("Menu");
	}
	public void NextScene(){
		pauseScript.gameEnded=false;
		first=true;
		Time.timeScale = 1;
		Application.LoadLevel("Level 2");
	}
    public void CampaignScene()
    {
        pauseScript.gameEnded = false;
        first = true;
        Time.timeScale = 1;
        Application.LoadLevel("campaign");
    }
    public void LoadHelp()
    {
        Application.LoadLevel("Help");
    }
}
