using UnityEngine;
using System.Collections;

public class Point : MonoBehaviour {

		private float x;
		private float y;

	public void Set(float x, float y) {
		this.x = x;
		this.y = y;
	}

	public float GetX(){
		return x;
	}

	public float GetY() {
		return y;
	}

}