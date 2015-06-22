using UnityEngine;
using System.Collections;

public class TowerAnimation : MonoBehaviour {

	int i;

	// Use this for initialization
	void Start () {
		i = 0;
		StartCoroutine (anim ());
		
	
	}

	int next (int x) {
		int mod = transform.childCount;
		x++;
		return x % mod;
	}

	IEnumerator anim () {

		while (true) {
			if (gameObject.activeSelf) {

				transform.GetChild (i).gameObject.SetActive (false);
				transform.GetChild (next(i)).gameObject.SetActive (true);
				i = (i+1) % transform.childCount;
			}
			yield return new WaitForSeconds (0.4f);
		}

	}
	// Update is called once per frame
	void Update () {
	
	}
}
