using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;


public class Spawn : MonoBehaviour {
	// listy wrogów dla danych fal
	//List<List<GameObject>> enemy = new List<List<GameObject>>();

	 List <GameObject> enemy1 = new List<GameObject>();
	 List <GameObject> enemy2 = new List<GameObject>();
	 List <GameObject> enemy3 = new List<GameObject>();
	 List <GameObject> enemy4 = new List<GameObject>();
	 List <GameObject> enemy5 = new List<GameObject>();
	 List <GameObject> enemy6 = new List<GameObject>();
	 List <GameObject> enemy0 = new List<GameObject>();

	/* element 0 ilość enemy
	 * element 1 ilość enemy1
	 */
	public List<int> numberToSpawnInFirstWave;
	public List<int> numberToSpawnInSecondWave;
	public List<int> numberToSpawnInThirdWave;
	public List<int> numberToSpawnInFourthWave;
	public List<int> numberToSpawnInFifthWave;
	public List<int> numberToSpawnInSixthWave;
	public List<int> numberToSpawnInSeventhWave;

	public GameObject progressBarNextWave;
	Image progressBarImage;

	public bool sendNextWave=false;
	List<int> enemySpawned =new List<int>();
	public string direction;
	public GameObject spawnPoint;
	private int enemyMoved=0;  //ile wrogow jest wprawionych w ruch

	System.DateTime whenDeactiveNextWaveButton; 
	//ProgressBar nextWaveProgressBar = new ProgressBar ();
	
	private bool oneSpawned = false;

	int numberOfWavesLeft=0;

	public GameObject NextWaveGameObject;
	public int NextWaveButtonInterval;
	public int NextWaveTimeInterval;
	//int numberOfWaves=7; //ilosc fal
	bool nextWaveButtonClickedFirstTime=false;

	float t;
	float progressBarCounter=0;

	public int waveReleased=0;  //ktora fala zostala wypuszczona
	List<List<int>> allWaves=new List<List<int>>();

	GameObject pause;
	Pause pauseScript;
    public GameObject Player;

    public int numberOfEnemy;

	public void isClickedNextWaved()
	{
		if (pauseScript.isPaused != true) {
			if (!nextWaveButtonClickedFirstTime) {
				InvokeRepeating ("PushNextWave", 2, 1F);
			
				nextWaveButtonClickedFirstTime = true;
			}
		
			//Debug.Log ("isClickedNextWaved");
			if (waveReleased < allWaves.Count)
				LoadNextWave ();
			whenDeactiveNextWaveButton = System.DateTime.Now;
			restartProgressBar ();
			restart = true;
			NextWaveGameObject.SetActive (false);

			progressBarNextWave.SetActive (false);
			//progressBarImage.re
			numberOfWavesLeft = numberOfWavesLeft - 1;
            
            Player.GetComponent<Player>().addGold(50);
            Debug.Log("Next Wave clicked. Added 50 gold");
 
        }
	}

	bool restart=true;
	void ActiveNextWavedButton()
	{
		//Debug.Log (numberOfWavesLeft);
		if (numberOfWavesLeft > 0) {

			//Debug.Log (((System.DateTime.Now - whenDeactiveNextWaveButton) >= System.TimeSpan.FromSeconds (30)).ToString ());
			if (whenDeactiveNextWaveButton != null) {
				//double amount = ((System.DateTime.Now - whenDeactiveNextWaveButton));
				//nextWaveProgressBar.fillProgressBar((((System.DateTime.Now - whenDeactiveNextWaveButton).TotalSeconds)*100/(System.TimeSpan.FromSeconds(NextWaveButtonInterval)).TotalSeconds));
				//nextWaveProgressBar.fillProgressBar(amount);

				//Debug.Log(pauseScript.whenResrumed-pauseScript.whenPaused);
				if (pauseScript.whenResrumed>=pauseScript.whenPaused)
				{
					whenDeactiveNextWaveButton=whenDeactiveNextWaveButton+ (pauseScript.whenResrumed-pauseScript.whenPaused);
					pauseScript.resetWhen();
				}
				if ((pauseScript.whenResrumed>=pauseScript.whenPaused)){
					if (((System.DateTime.Now) - whenDeactiveNextWaveButton) >= System.TimeSpan.FromSeconds (NextWaveButtonInterval)) {
						if (restart) 
						{
							restartProgressBar ();
							restart=false;
						}
						progressBarNextWave.SetActive(true);

						NextWaveGameObject.SetActive (true);
						if (progressBarImage.fillAmount<=0) restartProgressBar ();


						pauseScript.whenResrumed=new DateTime();
						pauseScript.whenPaused=new DateTime();
					}
				}
			}
		} else
			CancelInvoke ("PushNextWave");
	}

	void PushNextWave()
	{
		if (numberOfWavesLeft >= 0 && whenDeactiveNextWaveButton != null ) {

			//Debug.Log (((System.DateTime.Now - whenDeactiveNextWaveButton) >= System.TimeSpan.FromSeconds (30)).ToString ());
			{

				if (pauseScript.whenResrumed>=pauseScript.whenPaused)
				{
					whenDeactiveNextWaveButton=whenDeactiveNextWaveButton+ (pauseScript.whenResrumed-pauseScript.whenPaused);
					pauseScript.resetWhen();
				}
				{

					if ((System.DateTime.Now - whenDeactiveNextWaveButton) >= System.TimeSpan.FromSeconds (NextWaveTimeInterval))
					{
						//Debug.Log ((System.DateTime.Now - whenDeactiveNextWaveButton).ToString());
					
						isClickedNextWaved();

						//numberOfWavesLeft=numberOfWavesLeft-1;
					}
				}
				
			}
		}
	}
	void Start () {
		for (int i =0; i<7; i++) {
			enemySpawned.Add (0);
		}
		FillAllWaves ();
		//Debug.Log (allWaves[0][1].ToString());
		NumerOfWaves ();
		//LoadNextWave();
		progressBarImage = progressBarNextWave.GetComponent<Image> ();

		pause = GameObject.Find ("Pause");
		pauseScript= (Pause) pause.GetComponent(typeof(Pause));
		numberOfEnemy = howManyEnemy ();

        Player = GameObject.Find("Player");
    }	

	void FillAllWaves()
	{
		if (numberToSpawnInFirstWave.Count!=0)
			allWaves.Add(numberToSpawnInFirstWave);
        if (numberToSpawnInSecondWave.Count != 0)
            allWaves.Add(numberToSpawnInSecondWave);
        if (numberToSpawnInThirdWave.Count != 0)
            allWaves.Add(numberToSpawnInThirdWave);
        if (numberToSpawnInFourthWave.Count != 0)
            allWaves.Add(numberToSpawnInFourthWave);
        if (numberToSpawnInFifthWave.Count != 0)
            allWaves.Add(numberToSpawnInFifthWave);
        if (numberToSpawnInSixthWave.Count != 0)
            allWaves.Add(numberToSpawnInSixthWave);
        if (numberToSpawnInSeventhWave.Count != 0)
            allWaves.Add(numberToSpawnInSeventhWave);
    }

	void NumerOfWaves()
	{
		if (numberToSpawnInFirstWave.Count != 0)
			numberOfWavesLeft = numberOfWavesLeft + 1;
		if (numberToSpawnInSecondWave.Count!=0)
			numberOfWavesLeft = numberOfWavesLeft + 1;
		if (numberToSpawnInThirdWave.Count!=0)
			numberOfWavesLeft = numberOfWavesLeft + 1;
		if (numberToSpawnInFourthWave.Count!=0)
			numberOfWavesLeft = numberOfWavesLeft + 1;
		if (numberToSpawnInFifthWave.Count!=0)
			numberOfWavesLeft = numberOfWavesLeft + 1;
		if (numberToSpawnInSixthWave.Count!=0)
			numberOfWavesLeft = numberOfWavesLeft + 1;
		if (numberToSpawnInSeventhWave.Count!=0)
			numberOfWavesLeft = numberOfWavesLeft + 1;
	}

	void SpawnEnemy(GameObject singleEnemy)
	{
		float x = this.transform.position.x;
		float y = this.transform.position.y;
		singleEnemy.transform.position = new Vector2 (UnityEngine.Random.Range(x-0.6F, x+0.6F), UnityEngine.Random.Range (y-0.6F,y+0.6F));
		singleEnemy.SetActive (true); 
		//Debug.Log(singleEnemy.transform.position.ToString()+ ":::"+this.transform.position.ToString());
		//singleEnemy.transform.position = this.transform.position;
        if (singleEnemy.GetComponent<EnemyMove>()==null) MoveEnemy(singleEnemy, singleEnemy.GetComponent<EnemyMoveEnemy3>().speed);
        else
        MoveEnemy(singleEnemy, singleEnemy.GetComponent<EnemyMove>().speed);
	}


	void LoadNextWave()
	{
		//Debug.Log ("Wczytywanie fali:"+ waveReleased.ToString());

		if (waveReleased==0) LoadWave (waveReleased, enemy0);
			else
		if (waveReleased==1) LoadWave (waveReleased, enemy1);
			else 
		if (waveReleased==2) LoadWave (waveReleased, enemy2);
			else
		if (waveReleased==3) LoadWave (waveReleased, enemy3);
			else
		if (waveReleased==4) LoadWave (waveReleased, enemy4);
			else
		if (waveReleased==5) LoadWave (waveReleased, enemy5);
			else
		if (waveReleased==6) LoadWave (waveReleased, enemy6);

			
		Debug.Log ("Wczytano fale:"+ waveReleased.ToString());
	}

	//tutaj ładowani są wrogowie do listy Gameobject
	void LoadWave(int whichWave, List <GameObject> enemySingleWave)
	{
		//Debug.Log ("Wszystkich fal:"+ allWaves.Count.ToString());
		if (waveReleased < allWaves.Count) {
			//kiedy dojdzie wiecej wrogow trzeba dodac wiecej warunkow
            print (allWaves[whichWave][2]);
			while (allWaves[whichWave][0]!=0 || allWaves[whichWave][1]!=0 || allWaves[whichWave][2] != 0)
			{
				for (int whichEnemy=0;whichEnemy<allWaves[whichWave].Count;whichEnemy++)
				{
					if (whichEnemy==0 && allWaves[whichWave][0]!=0)
					{
						enemySingleWave.Add(Instantiate (Resources.Load("Enemy")) as GameObject);
						enemySingleWave[whichEnemy].transform.position = this.transform.position;
						
						allWaves[whichWave][whichEnemy]=allWaves[whichWave][whichEnemy]-1;
						//Debug.Log("Dodano Enemy1 do listy");
						
						//enemy[whichEnemy].SetActive(false);
						//Debug.Log(enemy[whichEnemy].transform.position.ToString()+ ":::"+this.transform.position.ToString());

						//enemy[whichEnemy].transform.position = this.transform.position;

					}
					else
						if (whichEnemy==1 && allWaves[whichWave][1]!=0)
					{
						enemySingleWave.Add(Instantiate (Resources.Load("Enemy2")) as GameObject);
						enemySingleWave[whichEnemy].transform.position = this.transform.position;
						
						allWaves[whichWave][whichEnemy]=allWaves[whichWave][whichEnemy]-1;
                        //Debug.Log(enemy[whichEnemy].transform.position.ToString()+ ":::"+this.transform.position.ToString());
                        //enemy[whichEnemy].SetActive(false);	
                        
					}
                    else
                        if (whichEnemy == 2 && allWaves[whichWave][2] != 0)
                    {
                        enemySingleWave.Add(Instantiate(Resources.Load("Enemy3")) as GameObject);
                        enemySingleWave[whichEnemy].transform.position = this.transform.position;

                        allWaves[whichWave][whichEnemy] = allWaves[whichWave][whichEnemy] - 1;
                        //Debug.Log(enemy[whichEnemy].transform.position.ToString()+ ":::"+this.transform.position.ToString());
                        //enemy[whichEnemy].SetActive(false);	
                    }
                    //print(whichEnemy);

                }
			}
			waveReleased=waveReleased+1;
			foreach (GameObject singleEnemy in enemySingleWave) 
			{
				singleEnemy.transform.position = this.transform.position;
				singleEnemy.SetActive(false);
			}
		}
	}

	void MoveEnemy(GameObject singleEnemy, float speed)
	{
		/*if (enemyMoved <= enemySpawned)*/ {
			if (direction == "toDown")
				singleEnemy.GetComponent<Rigidbody2D> ().velocity = (new Vector2 (0f, -speed));
			else
				if (direction == "toUp")
				singleEnemy.GetComponent<Rigidbody2D> ().velocity = (new Vector2 (0f, speed));
			else 
				if (direction == "toRight")
				singleEnemy.GetComponent<Rigidbody2D> ().velocity = (new Vector2 (speed, 0f));
			else 
				if (direction == "toLeft")
				singleEnemy.GetComponent<Rigidbody2D> ().velocity = (new Vector2 (-speed, 0f));
			enemyMoved++;

		}
	}
	public int howManyEnemy()
	{
		int amount=0;
		foreach (List<int> wave in allWaves)
		{
			foreach(int i in wave)
			{
				amount=amount+i;
			}

		}
        print("many: " + amount.ToString());
		return amount;
	}
	// Update is called once per frame
	void Update () {

		if (waveReleased!=0) fillProgressBar ();
		//SpawnEnemy ();
		//System.DateTime moment = new System.DateTime.Now;
		t = Time.time;
		//ebug.Log (waveReleased.ToString());


		if ((System.DateTime.Now.Second % 2 == 0) && (oneSpawned==false) /* &&  enemySpawned<enemy.Count*/) 
		{ //w parzyste sekundy rusza enemy
			ActiveNextWavedButton();
			//PushNextWave();
			//Debug.Log(( ).ToString());
			for (int i=0;i<waveReleased;i++)
			{
				if (i==0 && enemy0.Count>enemySpawned[0]) {
					//Debug.Log(enemy0[enemySpawned[0]]);
					SpawnEnemy(enemy0[enemySpawned[0]]);
					enemySpawned[0]=enemySpawned[0]+1;
				}
				else
				if (i==1 && enemy1.Count>enemySpawned[i]) {
				
					SpawnEnemy(enemy1[enemySpawned[1]]);
					enemySpawned[1]=enemySpawned[1]+1;
				}

				else 
				if (i==2 && enemy2.Count>enemySpawned[i]) {

					SpawnEnemy(enemy2[enemySpawned[i]]);
					enemySpawned[i]=enemySpawned[i]+1;
				}
				else
				if (i==3 && enemy3.Count>enemySpawned[i]) {

					SpawnEnemy(enemy3[enemySpawned[i]]);
					enemySpawned[i]=enemySpawned[i]+1;
				}
				else
				if (i==4 && enemy4.Count>enemySpawned[i]) {

					SpawnEnemy(enemy4[enemySpawned[i]]);
					enemySpawned[i]=enemySpawned[i]+1;
				}
				else
				if (i==5 && enemy5.Count>enemySpawned[i]) {

					SpawnEnemy(enemy5[enemySpawned[i]]);
					enemySpawned[i]=enemySpawned[i]+1;
				}
				else
				if (i==6  && enemy6.Count>enemySpawned[i]) {

					SpawnEnemy(enemy6[enemySpawned[i]]);
					enemySpawned[i]=enemySpawned[i]+1;
				}
					
			}
			//enemySpawned=enemySpawned+1;
			oneSpawned=true;
		}
		else
		if ((System.DateTime.Now.Second % 2 != 0))
			oneSpawned = false;
	}
	public void fillProgressBar()
	{
		progressBarImage.fillAmount = Mathf.InverseLerp(1F,0F,progressBarCounter);
		
		if (progressBarCounter < 1){ // while t below the end limit...
			// increment it at the desired rate every update:
			//Debug.Log (progressBarCounter);
			progressBarCounter += Time.deltaTime/(NextWaveTimeInterval-NextWaveButtonInterval);
		}
	}
	public void restartProgressBar()
	{
		progressBarCounter = 0;
	}
}
