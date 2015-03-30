using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {
	public float speed; //predkosc wroga
	Rigidbody2D player;
	bool firstPath = true;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		player = GetComponent<Rigidbody2D> ();
	
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		player = GetComponent<Rigidbody2D> ();
		Debug.Log("Something has entered this zone."+ col.gameObject.tag);

		if (firstPath) {
			firstPath = false;
			//pierwsze wejscie na sciezke
			if (col.gameObject.tag == "RTLTR" || col.gameObject.tag == "RTUTR" || col.gameObject.tag == "RTDTR") {
			
				player.AddForce (new Vector2 (-(speed), 0f));
			
			}else
			if (col.gameObject.tag == "UTDTU" || col.gameObject.tag == "UTLTU" || col.gameObject.tag == "UTRTU" ) {
				
				player.AddForce (new Vector2 (0f, -speed));
				
			}else
			if (col.gameObject.tag == "DTUTD" || col.gameObject.tag == "DTLTD" || col.gameObject.tag == "DTRTD") {
				
				player.AddForce (new Vector2 (0f, speed));
				
			}else
			if (col.gameObject.tag == "LTDTL" || col.gameObject.tag == "LTUTL" || col.gameObject.tag == "LTRTL") {
				
				player.AddForce (new Vector2 (speed, 0f));
				
			}

		} else {

			//zakrety
			if (col.gameObject.tag == "UTLTL" || col.gameObject.tag == "LTUTU") {
				
				player.AddForce (new Vector2 (-speed, speed));
			} else

			if (col.gameObject.tag == "UTRTR" || col.gameObject.tag == "RTUTU") {
				
				player.AddForce (new Vector2 (speed, speed));
			}else
			if (col.gameObject.tag == "DTLTL" || col.gameObject.tag == "LTDTD") {
				
				player.AddForce (new Vector2 (-speed, -speed));
			}else
			if (col.gameObject.tag == "DTRTR" || col.gameObject.tag == "RTDTD") {
				
				player.AddForce (new Vector2 (speed, -speed));
			}






		}
	}
}
