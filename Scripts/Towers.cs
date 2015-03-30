using UnityEngine;
using System.Collections;




public class Towers : MonoBehaviour {

	List<int> list = new List<int>();
	//----------------------------------
	public int T_level;
	public int demage;
	public int perSec;
	public int radius;
	public Point TowerCord = new Point();

	public Towers(int x, int y){
		this.TowerCord.Set (x, y);
	}

	void ActionOnEnemy(){
		//for all enemies

	}
	void Shoot() {

		if (
	}

	void LevelUpgrade(){
		//demage = 
	}

	int distance(Point a, Point b) {
		//calculate distanc
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


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
