using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Spawn : MonoBehaviour {
	public List <GameObject> enemy = new List<GameObject>();

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


	int enemySpawned=0;
	public string direction;
	public GameObject spawnPoint;
	private int enemyMoved=0;  //ile wrogow jest wprawionych w ruch
	// Use this for initialization
	private bool oneSpawned = false;

	public int waveInterval;

	float t;

	int waveReleased=0;  //ktora fala zostala wypuszczona
	List<List<int>> allWaves=new List<List<int>>();

	void Start () {
		FillAllWaves ();
		//Debug.Log (allWaves[0][1].ToString());
		LoadNextWave();
	
	}	
	
	void FillAllWaves()
	{
		allWaves.Add(numberToSpawnInFirstWave);
		allWaves.Add(numberToSpawnInSecondWave);
		allWaves.Add(numberToSpawnInThirdWave);
		allWaves.Add(numberToSpawnInFourthWave);
		allWaves.Add(numberToSpawnInFifthWave);
		allWaves.Add(numberToSpawnInSixthWave);
		allWaves.Add(numberToSpawnInSeventhWave);


	}

	void SpawnEnemy(GameObject singleEnemy)
	{
		singleEnemy.SetActive (true); 
		singleEnemy.transform.position = this.transform.position;

		MoveEnemy(singleEnemy, singleEnemy.GetComponent<EnemyMove>().speed);
	}


	void LoadNextWave()
	{
		LoadWave (waveReleased);

	}

	//tutaj ładowani są wrogowie do listy Gameobject
	void LoadWave(int whichWave)
	{
		Debug.Log ("Wszystkich fal:"+ allWaves.Count.ToString());
		if (waveReleased < allWaves.Count) {
			//kiedy dojdzie wiecej wrogow trzeba dodac wiecej warunkow
			while (allWaves[whichWave][0]!=0 || allWaves[whichWave][1]!=0)
			{
				for (int whichEnemy=0;whichEnemy<allWaves[whichWave].Count;whichEnemy++)
				{
					if (whichEnemy==0 && allWaves[whichWave][0]!=0)
					{
						enemy.Add(Instantiate (Resources.Load("Enemy")) as GameObject);
						allWaves[whichWave][whichEnemy]=allWaves[whichWave][whichEnemy]-1;
						//Debug.Log("Dodano Enemy1 do listy");
						enemy[whichEnemy].SetActive(false);
						

					}
					else
						if (whichEnemy==1 && allWaves[whichWave][1]!=0)
					{
						enemy.Add(Instantiate (Resources.Load("Enemy2")) as GameObject);
						allWaves[whichWave][whichEnemy]=allWaves[whichWave][whichEnemy]-1;
						//Debug.Log("Dodano Enemy2 do listy");
						enemy[whichEnemy].SetActive(false);

					}
				}
			}
			waveReleased=waveReleased+1;
		}
	}

	void MoveEnemy(GameObject singleEnemy, float speed)
	{
		/*if (enemyMoved <= enemySpawned)*/ {
			if (direction == "toDown")
				singleEnemy.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0f, -speed));
			else
				if (direction == "toUp")
				singleEnemy.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0f, speed));
			else 
				if (direction == "toRight")
				singleEnemy.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (speed, 0f));
			else 
				if (direction == "toLeft")
				singleEnemy.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-speed, 0f));
			enemyMoved++;

		}
	}
	// Update is called once per frame
	void Update () {
		//SpawnEnemy ();
		//System.DateTime moment = new System.DateTime.Now;
		t = Time.time;
		//Debug.Log (t.ToString());
		if ((System.DateTime.Now.Second % 2 == 0) && (oneSpawned==false) && enemySpawned<enemy.Count) 
		{ //w parzyste sekundy rusza enemy
			SpawnEnemy(enemy[enemySpawned]);
			enemySpawned=enemySpawned+1;
			oneSpawned=true;
		}
		else
		if ((System.DateTime.Now.Second % 2 != 0))
			oneSpawned = false;
	
		
	}
}
