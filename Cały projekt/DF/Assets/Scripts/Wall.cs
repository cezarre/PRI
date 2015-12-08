using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            if (coll.gameObject.GetComponent<EnemyMove>() == null)
                coll.gameObject.GetComponent<EnemyMoveEnemy3>().WallSpeedZero();
            else
                coll.gameObject.GetComponent<EnemyMove>().WallSpeedZero();

        }

    }
}
