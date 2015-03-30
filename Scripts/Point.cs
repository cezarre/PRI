using UnityEngine;
using System.Collections;

public class Point : MonoBehaviour {

		private int x;
		private int y;

	public void Set(int x, int y) {
		this.x = x;
		this.y = y;
	}

	public int GetX(){
		return x;
	}

	public int GetY() {
		return y;
	}

}