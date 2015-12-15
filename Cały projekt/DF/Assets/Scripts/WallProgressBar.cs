using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WallProgressBar : MonoBehaviour {
    public GameObject wall;
    int secondToNextWall;
    // Use this for initialization
    Image progressBar;
	void Start () {
        secondToNextWall = wall.GetComponent<Wall>().secondToLoadNewWall;
        progressBar = GetComponent<Image>();
        progressBar.fillAmount = 1;

    }
    float k = 0;
    // Update is called once per frame
    bool dropped=false;
    void Update() {
        if (wall.GetComponent<Wall>().dropped == true)
        {
            
            dropped = true;
        }
        if (dropped && wall.GetComponent<Wall>().numberOfWall > 0)
        {

            wall.GetComponent<Wall>().abilityBlocked = true;
            k += 1.0f / secondToNextWall * Time.deltaTime;
            progressBar.fillAmount = k;
            print(k.ToString());
            if (k >= 1.0f)
            {
                wall.GetComponent<Wall>().abilityBlocked = false;
                dropped = false;
                k = 0;


            }
        }
        if (!(wall.GetComponent<Wall>().numberOfWall > 0))
        {
            progressBar.fillAmount = 0;
        }
    }

    bool startLoad()
    {
        if (wall.active == false) return true;
        else return true;


    }
	
	





}
