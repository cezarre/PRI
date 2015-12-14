using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
    public GameObject enemy;
    // Use this for initialization
    float startHp;
    Image healthBar;
    void Start () {
        startHp = CurrentHp();
        healthBar = GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 wantedPos = Camera.main.WorldToScreenPoint(enemy.transform.position);
        transform.position = new Vector3(wantedPos.x, wantedPos.y+15, wantedPos.z);
        healthBar.fillAmount =  CurrentHp()/ startHp;
        //print((startHp / CurrentHp()).ToString());
    }

    float CurrentHp()
    {
        if (enemy.GetComponent<EnemyMove>() != null)
            return  enemy.GetComponent<EnemyMove>().hp;
        else
            return enemy.GetComponent<EnemyMoveEnemy3>().hp;
    }
    
}
