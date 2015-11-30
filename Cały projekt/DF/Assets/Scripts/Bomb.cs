using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Bomb : MonoBehaviour {
    public bool isActive = false;
    public int numberOfExplosion;
    // Use this for initialization
    Vector3 newPosition;
    GameObject[] enemyInRange=new GameObject[30];
    Animator explosion;
    SpriteRenderer currentSprite;
    void Start () {
        newPosition = transform.position;
        explosion = GetComponent<Animator>();
        currentSprite = GetComponent<SpriteRenderer>();
        // explosion.Stop();
        GameObject.FindGameObjectWithTag("BombAbbilityProgress").GetComponent<ProgressBarBomb>().startPoints = numberOfExplosion;
        gameObject.SetActive(false);
         
    }
	
	// Update is called once per frame
	void Update () {
        BombFollowMouse();
        DropBomb();
        if (currentSprite.sprite.name == "010")
        {
            isActive = false;
            firstClick = false;
            firstClickAfterActive = false;
            transform.position = new Vector3(0, 0, -10);
            gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("BombAbbilityProgress").GetComponent<ProgressBarBomb>().FillProgressBarPoints(numberOfExplosion);

        }

        if (numberOfExplosion < 0){
            GameObject button = GameObject.FindGameObjectWithTag("BombAbbility");

            button.SetActive(false);
            //Destroy(gameObject);
        }


    }
    bool firstClick = false;
    public void ActiveBomb()
    {
        
        if (!firstClick && numberOfExplosion>0)
        {

            firstClick = true;
            isActive = true;
            gameObject.SetActive(true);
        }
        else
        {
            CancelBomb();
            
        }
    }
    void CancelBomb()
    {
        if (currentSprite.sprite.name == "011" || currentSprite.sprite.name == "000")
        {
            isActive = false;
            firstClick = false;
            firstClickAfterActive = false;
          
            if (numberOfExplosion >= 0) numberOfExplosion++;
            
            
            gameObject.SetActive(false);
        }
    }

    void BombFollowMouse()
    {
        if (isActive && firstClick && !firstClickAfterActive)
        {
            float x = Input.mousePosition.x;
            float y = Input.mousePosition.y;
            float z = Input.mousePosition.z;
            Vector3 tans = Camera.main.ScreenToWorldPoint(new Vector3(x, y, 0));
            //print(tans.ToString());
            tans = new Vector3(tans.x, tans.y, 0);
            transform.position = tans;
        }
    }
    bool firstClickAfterActive=false;
    void DropBomb()
    {
        if (isActive)
        {
            if (Input.GetMouseButtonDown(0) && !explosion.GetBool("explosion") && !firstClickAfterActive)
            {
                firstClickAfterActive = true;
                float x = Input.mousePosition.x;
                float y = Input.mousePosition.y;
                float z = Input.mousePosition.z;
                Vector3 tans = Camera.main.ScreenToWorldPoint(new Vector3(x, y, 0));
                //print(tans.ToString());
                tans = new Vector3(tans.x, tans.y, 0);
                transform.position = tans;
               
                explosion.SetBool("explosion", true);

                numberOfExplosion--;

            }
        }
    }
    void OnTriggerStay2D(Collider2D coll)
    {
        if (isActive && firstClickAfterActive)
        {
            
            if (currentSprite.sprite.name == "006")
            {
                coll.gameObject.GetComponent<EnemyMove>().damage(30.0f);
                print("stay");

            }
        }

            
    }
   
   
 
}
