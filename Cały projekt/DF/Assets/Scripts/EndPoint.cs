using UnityEngine;
using System.Collections;

public class EndPoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	void OnTriggerEnter2D(Collider2D col)
	{
        if (col.gameObject.tag == "Enemy")
        {
            if (col.gameObject.GetComponent<EnemyMove>() == null)
                col.gameObject.GetComponent<EnemyMoveEnemy3>().EndPointReached();
            else
                col.gameObject.GetComponent<EnemyMove>().EndPointReached();
        }
	}

	// Update is called once per frame
	void Update () {
	
	}
}
