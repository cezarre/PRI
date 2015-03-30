using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

	public Point myPoint = new Point ();
	private int hp;

	public Enemy (int x, int y)
	{
		this.myPoint.Set (x, y);
	}

	public void damage (int d)
	{
		hp -= d;
	}

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
