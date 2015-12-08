using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy4DisableTower : MonoBehaviour {
    List<GameObject> tower = new List<GameObject>();
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
 
    void OnTriggerEnter2D(Collider2D col)

    {
        if(col.gameObject.tag=="Tower")
        {
            col.gameObject.GetComponent<Towers>().TowerBlock(true);
            //col.gameObject.GetComponent<Towers>().Invoke("TowerEnable", 2);
           // print("Tower disabled");

        }

    }

}
