using UnityEngine;
using System.Collections;

public class EndPoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		col.gameObject.GetComponent<EnemyMove> ().EndPointReached();
	}

	// Update is called once per frame
	void Update () {
	
	}
}
