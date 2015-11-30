using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ProgressBarBomb : MonoBehaviour {
    Image progressBar;
    float duration = 5;
    public float startPoints;
    void Start()
    {

        progressBar = GetComponent<Image>();
       



    }
    
	
	// Update is called once per frame
	void Update () {
        
	}
    public void FillProgressBarPoints(float actualPoints)
    {
        print((1 / startPoints) * actualPoints);
        progressBar.fillAmount = (1 / startPoints) * actualPoints;
    }
}
