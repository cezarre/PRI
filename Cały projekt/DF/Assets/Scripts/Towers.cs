using UnityEngine;
using System.Collections;
using System.Collections.Generic;




public class Towers : MonoBehaviour {

	public List <GameObject> enemies = new List<GameObject>();

	IEnumerator Start()
	{
		damage = 0;
		radius = 10;
		timeInterval = 4f;
		type3 = false;
		TowerCord = gameObject.AddComponent<Point>();
		TowerCord.Set (gameObject.transform.position.x, gameObject.transform.position.y);


		yield return new WaitForSeconds(1);
		LoadEnemies ();
		StartCoroutine(Actioning ());

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
			ActionOnEnemy ();
			yield return new WaitForSeconds (timeInterval);
		}
	}

	void ActionOnEnemy(){

		LoadEnemies();
		foreach (GameObject enemy in enemies) {

			if (DetectedEnemy(enemy)) {
				if (type3) {
					AreaShoot(enemy);
				} else {
					Shoot(enemy);
				}


				break;
				//other actions, if any
			}
		}

	}

	void Shoot(GameObject enemy) {
		enemy.GetComponent<EnemyMove>().damage(damage);
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
	void BuildTesla() {
		transform.FindChild ("Tesla").gameObject.SetActive (true);
		damage = 11;
		radius = 10;
		timeInterval = 4f;

	}


	void OnMouseDown() {
		//print ("KID: " + transform.root.GetChild (0).name);

		transform.FindChild ("TowerPlace").gameObject.SetActive (false);
		BuildTesla ();




	}


	void LevelUpgrade(){
		//Change t_level
	}


	

	// Update is called once per frame
	void Update () {


		//Debug.Log("From tower: " + enemies.Count);
	}
}
