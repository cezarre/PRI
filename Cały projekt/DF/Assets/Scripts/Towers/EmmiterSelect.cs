using UnityEngine;
using System.Collections;

public class EmmiterSelect : MonoBehaviour {

    public int Price;
    int Price1;
    int Price2;
    int Price3;

    // Use this for initialization
    void Start () {
        Price1 = 50;
        Price2 = 100;
        Price3 = 200;

        Price = Price1;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {

		int t = transform.parent.parent.GetComponent<Towers> ().TowerType;
        int t_level = transform.parent.parent.GetComponent<Towers>().t_level;

        if (t == 0 || t == 3) {
            if (t_level < 3)
            {
                if (t_level == 0 && transform.parent.parent.GetComponent<Towers>().PlayerGoldStatus() >= Price)
                {
                    transform.parent.parent.GetComponent<Towers>().addGoldToPlayer(-Price);
                    JustBuild();
                    Price = Price2;

                }
                if (t_level == 1 && transform.parent.parent.GetComponent<Towers>().PlayerGoldStatus() >= Price)
                {
                    transform.parent.parent.GetComponent<Towers>().addGoldToPlayer(-Price);
                    JustBuild();
                    Price = Price3;

                }
                if (t_level == 2 && transform.parent.parent.GetComponent<Towers>().PlayerGoldStatus() >= Price)
                {
                    transform.parent.parent.GetComponent<Towers>().addGoldToPlayer(-Price);
                    JustBuild();
                    Price = 9999;

                }


            }
            
            //transform.parent.parent.gameObject.GetComponent<Towers> ().BuildEmitter ();
        }
		
	}


    void JustBuild()
    {
        transform.parent.parent.gameObject.GetComponent<Towers>().BuildWait();
        transform.parent.parent.GetComponent<Towers>().TowerType = 3;
    }

   public void RestartPrice()
    {
        Price = Price1;
    }
}


