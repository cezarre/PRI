using UnityEngine;
using System.Collections;
using System.Collections.Generic;




public class Towers : MonoBehaviour {

	public List <GameObject> enemies = new List<GameObject>();
	List <GameObject> detectedEnemies = new List<GameObject>();

	IEnumerator Start()
	{
		block = false;
		t_level = 0;
		damage = 0;
		radius = 10;
		timeInterval = 4f;
		type3 = false;
		TowerCord = gameObject.AddComponent<Point>();
		TowerCord.Set (gameObject.transform.position.x, gameObject.transform.position.y);
		TowerType = 0;


		yield return new WaitForSeconds(1);
		LoadEnemies ();
		StartCoroutine(Actioning ());
		Player = GameObject.Find("Player");

	}

	public void LoadEnemies() {
		enemies.Clear ();
		foreach(GameObject enem in GameObject.FindGameObjectsWithTag("Enemy"))
		{
			enemies.Add (enem);
		}
	}
	
	//----------------------------------

	public int t_level;
	public float damage;
	public float areaDamageDist;
	public float timeInterval;
	public float radius;
	public bool type3;
	public Point TowerCord;
	public GameObject Player;
	public int TowerType;

	private bool block;

	float distance(Point a, Point b) {
		//calculate distance
		float x = a.GetX () - b.GetX ();
		float y = a.GetY () - b.GetY ();
		
		return Mathf.Sqrt (x * x + y * y);
	}

	private Point enemyToPoint (GameObject enemy) {
		Point tempP = gameObject.AddComponent<Point>();
		tempP.Set (enemy.transform.position.x, enemy.transform.position.y);
		return tempP;
	}

	bool DetectedEnemy(GameObject enemy) {

		if (distance (enemyToPoint(enemy), TowerCord) <= radius) {
			return true;
		} else {
			return false;
		}
	}

	IEnumerator Actioning() {
		while(true) {
			if (block == false) {
				ActionOnEnemy ();
			}
			yield return new WaitForSeconds (timeInterval);
		}
	}

	void ActionOnEnemy(){
		float bestDistance = 0;
		LoadEnemies();
		//GameObject enemyWithBestDistance = new GameObject ();
		int enemyWithBestDistance =0;
		detectedEnemies.Clear();

		foreach (GameObject enemy in enemies) {
			if (DetectedEnemy(enemy)) {
				detectedEnemies.Add(enemy);
			}
		}
		//foreach (GameObject enemy in detectedEnemies) {
		for (int i=0 ; i<detectedEnemies.Count ; i++){
            float dist;
            if (detectedEnemies[i].GetComponent<EnemyMove>() == null)
            {
                dist = detectedEnemies[i].GetComponent<EnemyMoveEnemy3>().distance;
            }
            else dist = detectedEnemies[i].GetComponent<EnemyMove>().distance;
            if (bestDistance < dist){
				bestDistance = dist;
				enemyWithBestDistance = i;
			}
		}
		//}
		if (detectedEnemies.Count > 0 && t_level > 0) {
			if (type3) {
				//AreaShoot(detectedEnemies[enemyWithBestDistance]);
			} else {
				Shoot(detectedEnemies[enemyWithBestDistance]);
			}
		}

	}

	void bullet(GameObject enemy) {
		float x = this.transform.position.x;
		float y = this.transform.position.y;
		GameObject bullet = (GameObject)Instantiate(Resources.Load("TeslaBullet"));
		bullet.transform.position = new Vector2 (x, y+2);
		//float buletSize = bullet.transform.localScale;
		bullet.transform.localScale *= 1.7f;
		bullet.GetComponent<BulletMove> ().enemyPosition = enemy.transform.position;
		bullet.SetActive (true);
		bullet.GetComponent<BulletMove> ().damage = damage;
		//float speed = 0.01;
		//float step = speed * Time.deWltaTime;
		//bullet.transform.position = Vector2.MoveTowards (bullet.transform.position, bullet.transform.position * 2, step);

	}
	void Shoot(GameObject enemy) {
		bullet (enemy);
		//enemy.GetComponent<EnemyMove>().damage(damage);
	}


	void AreaShoot(GameObject enemy) {
		/*Shoot (enemy);

		foreach (GameObject otherEnemy in enemies) {
			float dist = distance(enemyToPoint(otherEnemy), enemyToPoint(enemy));
			if (dist < areaDamageDist) {
				otherEnemy.damage = (1 - dist/areaDamageDist) * damage;
			}
		}*/

	}

	//------------BUILDING TOWERS----------------
	void BuildTesla1() {
		transform.FindChild ("TowerPlace").gameObject.SetActive (false);
		t_level = 1;
		transform.FindChild ("Tesla").FindChild("Tesla1").gameObject.SetActive (true);
		damage = 11;
		radius = 10;
		timeInterval = 4f;
		Player.GetComponent<Player> ().addGold (-50);

	}
	void BuildTesla2() {
		t_level = 2;
		transform.FindChild ("Tesla").FindChild("Tesla1").gameObject.SetActive (false);
		transform.FindChild ("Tesla").FindChild ("Tesla2").gameObject.SetActive (true);
		damage = 16;
		radius = 12;
		timeInterval = 3f;
		Player.GetComponent<Player> ().addGold (-100);
	}
	void BuildTesla3() {
		t_level = 3;
		transform.FindChild ("Tesla").FindChild("Tesla2").gameObject.SetActive (false);
		transform.FindChild ("Tesla").FindChild ("Tesla3").gameObject.SetActive (true);
		damage = 22;
		radius = 15;
		timeInterval = 2f;
		Player.GetComponent<Player> ().addGold (-200);
	}

	public void BuildTesla(){
		TowerType = 1;
		if (t_level == 0 && Player.GetComponent<Player> ().gold >= 50) {
			BuildTesla1 ();
		}
		else if (t_level == 1 && Player.GetComponent<Player> ().gold >= 100) {
			BuildTesla2();
		}
		else if (t_level == 2 && Player.GetComponent<Player> ().gold >= 200) {
			BuildTesla3();
		}


	}
	//-----------------------------------------------------------------------------------------------------

	void BuildAlch1() {
		transform.FindChild ("TowerPlace").gameObject.SetActive (false);
		t_level = 1;
		transform.FindChild ("Alchemist").FindChild("Alchemist1").gameObject.SetActive (true);
		damage = 11;
		radius = 10;
		timeInterval = 4f;
		Player.GetComponent<Player> ().addGold (-50);
		
	}
	void BuildAlch2() {
		t_level = 2;
		transform.FindChild ("Alchemist").FindChild("Alchemist1").gameObject.SetActive (false);
		transform.FindChild ("Alchemist").FindChild ("Alchemist2").gameObject.SetActive (true);
		damage = 16;
		radius = 12;
		timeInterval = 3f;
		Player.GetComponent<Player> ().addGold (-100);
	}
	void BuildAlch3() {
		t_level = 3;
		transform.FindChild ("Alchemist").FindChild("Alchemist2").gameObject.SetActive (false);
		transform.FindChild ("Alchemist").FindChild ("Alchemist3").gameObject.SetActive (true);
		damage = 22;
		radius = 15;
		timeInterval = 2f;
		Player.GetComponent<Player> ().addGold (-200);
	}

	public void BuildAlch(){
		TowerType = 2;
		if (t_level == 0 && Player.GetComponent<Player> ().gold >= 50) {
			BuildAlch1 ();
		}
		else if (t_level == 1 && Player.GetComponent<Player> ().gold >= 100) {
			BuildAlch2();
		}
		else if (t_level == 2 && Player.GetComponent<Player> ().gold >= 200) {
			BuildAlch3();
		}
		
		//transform.FindChild ("Tower-UI").gameObject.SetActive (false);
	}

	void OnMouseDown() {
		//print ("KID: " + transform.root.GetChild (0).name);
		/*
		if (t_level == 0 && Player.GetComponent<Player> ().gold >= 50) {
			BuildTesla1 ();
		}
		else if (t_level == 1 && Player.GetComponent<Player> ().gold >= 100) {
			BuildTesla2();
		}
		else if (t_level == 2 && Player.GetComponent<Player> ().gold >= 200) {
			BuildTesla3();
		}
		*/

		transform.FindChild ("Tower-UI").gameObject.SetActive (!transform.FindChild ("Tower-UI").gameObject.activeSelf);


	}



	public void TowerBlock(bool b) {
		block = b;
	}
	

	// Update is called once per frame
	void Update () {

		//Debug.Log("From tower: " + enemies.Count);
	}
}
