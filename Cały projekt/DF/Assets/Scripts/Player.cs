using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {
	public int hp;
	public int gold;
	public int numberOfEnemy;

	GameObject HPGameObject, GoldGameObject, Spawn;
	Text HPText, GoldGameText;

	GameObject spawn, win, gameOver, retry,backToMenu;
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
		retry=GameObject.Find("Retry");
		backToMenu=GameObject.Find("BackMenu");

		win.SetActive (false);
		gameOver.SetActive(false);
		retry.SetActive (false);
		backToMenu.SetActive (false);


		pause = GameObject.Find ("Pause");
		pauseScript= (Pause) pause.GetComponent(typeof(Pause));

	
	}
	
	// Update is called once per frame
	bool first=true;
	void Update () {
		if (first) numberOfEnemy = spawnScript.numberOfEnemy;
		first = false;
		//Debug.Log ("liczba wrogow: " + numberOfEnemy.ToString ());
		if (numberOfEnemy == 0 && hp > 0) {
			//win
			win.SetActive(true);
			retry.SetActive(true);
			backToMenu.SetActive (true);
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
		Application.LoadLevel("menu");
	}
	public void NextScene(){
		pauseScript.gameEnded=false;
		first=true;
		Time.timeScale = 1;
		Application.LoadLevel("exampleScene2");
	}
}
