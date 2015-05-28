using UnityEngine;
using System.Collections;

public class BulletMove : MonoBehaviour {
	public Vector2 enemyPosition = Vector2.zero;
	public float damage = 0;
	// Use this for initialization
	void Start () {

	}

	void OnTriggerEnter2D(Collider2D collision) {
		//print("hit enemy");
		if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Enemy2") {
			//col.GetComponent<EnemyMove>().damage(damage);
			collision.gameObject.GetComponent<EnemyMove>().damage(damage);
			Destroy(gameObject);
		}

	}
	// Update is called once per frame
	void Update () {
		float speed = 20;
		float step = speed * Time.deltaTime;

		gameObject.transform.position = Vector2.MoveTowards (gameObject.transform.position, enemyPosition, step);

		Vector3 enemyPosition3D = new Vector3 (enemyPosition.x, enemyPosition.y, 0);
		if (gameObject.transform.position == enemyPosition3D) {
			Destroy(gameObject);
		}


	}
}
