using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Spawn : MonoBehaviour {
	public List <GameObject> enemy = new List<GameObject>();
	public int numberToSpawn = 10;
	int enemySpawned=0;
	public string direction;
	public GameObject spawnPoint;
	private float speed=0;
	private int enemyMoved=0;  //ile wrogow jest wprawionych w ruch
	// Use this for initialization
	private bool oneSpawned = false;

	void Start () {

	
	}	
	

	void SpawnEnemy()
	{

		if (enemySpawned < numberToSpawn) {
			enemy.Add(Instantiate (Resources.Load("Enemy")) as GameObject);
			//enemy[enemySpaned].GetComponent<Rigidbody2D>().isKinematic=true;

			enemy[enemySpawned].transform.position = this.transform.position;  
			enemySpawned++;
			if (enemySpawned==1) speed=enemy[0].GetComponent<EnemyMove>().speed;  //pobieranie wartosci speed ustawionej dla enemy
			
		}
		//Debug.Log(enemy.Count);
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Enemy") {

		}
	}
	void MoveEnemy(GameObject singleEnemy)
	{
		if (enemyMoved <= enemySpawned) {
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
		SpawnEnemy ();
		//System.DateTime moment = new System.DateTime.Now;


		if ((System.DateTime.Now.Second % 2 == 0) && (oneSpawned==false)) 
		{ //w parzyste sekundy rusza enemy
			MoveEnemy(enemy[enemyMoved]);
			oneSpawned=true;
		}
		else
		if ((System.DateTime.Now.Second % 2 != 0))
			oneSpawned = false;
		
	}
}
