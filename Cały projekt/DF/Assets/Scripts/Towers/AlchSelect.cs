using UnityEngine;
using System.Collections;

public class AlchSelect : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {

		int t = transform.parent.parent.GetComponent<Towers> ().TowerType;
        int t_level = transform.parent.parent.GetComponent<Towers>().t_level;
        if (t == 0 || t == 2) {
            if (t_level <  3)
            {
                if (t_level == 0 && transform.parent.parent.GetComponent<Towers>().PlayerGoldStatus() >= 50)
                {
                    transform.parent.parent.GetComponent<Towers>().addGoldToPlayer(-50);
                    JustBuild();
                }
                if (t_level == 1 && transform.parent.parent.GetComponent<Towers>().PlayerGoldStatus() >= 100)
                {
                    transform.parent.parent.GetComponent<Towers>().addGoldToPlayer(-100);
                    JustBuild();
                }
                if (t_level == 2 && transform.parent.parent.GetComponent<Towers>().PlayerGoldStatus() >= -200)
                {
                    transform.parent.parent.GetComponent<Towers>().addGoldToPlayer(-200);
                    JustBuild();
                }


            }

            //transform.parent.parent.gameObject.GetComponent<Towers> ().BuildEmitter ();
        }

    }


    void JustBuild()
    {
        transform.parent.parent.gameObject.GetComponent<Towers>().BuildWait();
        transform.parent.parent.GetComponent<Towers>().TowerType = 2;
    }
}


