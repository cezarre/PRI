﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {
	public int hp;
	public int gold;
	public int numberOfEnemy;

	GameObject HPGameObject, GoldGameObject, Spawn;
	Text HPText, GoldGameText;

	GameObject spawn, win, gameOver;
	Spawn spawnScript;

	GameObject pause;
	Pause pauseScript;

	// Use this for initialization
	void Start () {
		HPGameObject = GameObject.Find("Left Text");
		HPText = HPGameObject.GetComponent<Text> ();

		GoldGameObject = GameObject.Find("Right Text");
		GoldGameText = GoldGameObject.GetComponent<Text> ();

		HPText.text = hp.ToString ();
		GoldGameText.text = gold.ToString () + "$";

		spawn = GameObject.Find ("SpawnPoint");
		spawnScript= (Spawn) spawn.GetComponent(typeof(Spawn));
		win= GameObject.Find("You Win");
		gameOver=GameObject.Find("Game Over");

		win.SetActive (false);
		gameOver.SetActive(false);

		pause = GameObject.Find ("Pause");
		pauseScript= (Pause) pause.GetComponent(typeof(Pause));

	
	}
	
	// Update is called once per frame
	bool first=true;
	void Update () {
		if (first) numberOfEnemy = spawnScript.numberOfEnemy;
		first = false;
		Debug.Log ("liczba wrogow: " + numberOfEnemy.ToString ());
		if (numberOfEnemy == 0 && hp > 0) {
			//win
			win.SetActive(true);
			Time.timeScale = 0;
			pauseScript.gameEnded=true;
		}




	
	}
	public void decresseHp(int howMuchLessHp)
	{
		if (hp - howMuchLessHp <= 0) {
			hp = 0;

			//gameover
			gameOver.SetActive(true);
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
}
