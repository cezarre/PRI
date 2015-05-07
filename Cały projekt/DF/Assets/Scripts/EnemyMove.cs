using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {
	public float speed; //predkosc wroga
	Rigidbody2D player;
	bool firstPath = true;
	public float hp;

	Animator anim;

	void Start () {
		//hp = 10;
		anim = GetComponent<Animator> ();
		player = GetComponent<Rigidbody2D> ();

	}



	public void damage (float d)
	{
		hp -= d;
		if (hp <= 0) {
			Destroy (gameObject);
		}
	}
	public void EndPointReached()
	{
		Destroy (gameObject);
	}
	void FixedUpdate ()
	{
		ChangeDirection ();
	}
	
	// Update is called once per frame
	void Update () {

	
	}
	void OnTriggerEnter2D(Collider2D col)

	{


		//player = GetComponent<Rigidbody2D> ();
		//Debug.Log("Something has entered this zone."+ col.gameObject.tag);

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
	void ChangeDirection()
	{

		//player = GetComponent<Rigidbody2D> ();
		if (player.velocity.y < 0) { //to down
				anim.SetInteger ("Direction", 1);
		} else 
			if (player.velocity.y > 0) {//to up
				anim.SetInteger ("Direction", 3);
		} else
			if (player.velocity.x < 0) { //to left
				anim.SetInteger ("Direction", 0);
		} else
			if (player.velocity.x > 0) {//to right
				anim.SetInteger ("Direction", 2);
		}
		//Debug.Log (anim.GetInteger("Direction").ToString ());

	}
}
