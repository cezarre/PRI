using UnityEngine;
using System.Collections;




public class Towers : MonoBehaviour {
	//to class Board
	List<Enemy> enemies = new List<Enemy>();
	//----------------------------------

	public int t_level;
	public int damage;
	public int areaDamageDist;
	public int timeInterval;
	public int radius;
	public bool type3;
	public Point TowerCord = new Point();

	public Towers(int x, int y){
		this.TowerCord.Set (x, y);
	}

	int distance(Point a, Point b) {
		//calculate distance
		int x = a.GetX () - b.GetX ();
		int y = a.GetY () - b.GetY ();
		
		return Mathf.Sqrt (x * x + y * y);
	}

	bool DetectedEnemy(Point EnemyCord) {
		if (distance (EnemyCord, TowerCord) <= radius) {
			return true;
		} else {
			return false;
		}
	}

	void ActionOnEnemy(){

		foreach (Enemy enemy in enemies) {
			if (DetectedEnemy(enemy)) {
				if (type3) {
					AreaShoot(enemy);
				} else {
					Shoot(enemy);
				}

				//other actions, if any
			}
		}

	}

	void Shoot(Enemy enemy) {
		enemy.damage (damage);
	}

	void AreaShoot(Enemy enemy) {
		Shoot (enemy);

		foreach (Enemy otherEnemy in enemies) {
			int dist = distance(otherEnemy, enemy);
			if (dist < areaDamageDist) {
				otherEnemy.damage = (1 - dist/areaDamageDist) * damage;
			}
		}

	}

	void LevelUpgrade(){
		//Change t_level
	}



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//set shoot time interval
		ActionOnEnemy ();
	}
}
