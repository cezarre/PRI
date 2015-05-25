using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ProgressBar : MonoBehaviour {
	Image progressBar;
	float duration=5;
	float t;
	void Start()
	{

		progressBar = GetComponent<Image> ();
		t = 0;



	}
	void Update() {
		//fillProgressBar ();


	}

	public void fillProgressBar()
	{
		progressBar.fillAmount = Mathf.InverseLerp(1F,0F,t);
		
		if (t < 1){ // while t below the end limit...
			// increment it at the desired rate every update:
			t += Time.deltaTime/duration;
		}

	}
	public void restartProgressBar()
	{
		t = 0;

	}
}