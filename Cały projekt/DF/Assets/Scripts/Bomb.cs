using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Bomb : MonoBehaviour
{
    public bool isActive = false;
    public int numberOfExplosion;
    CircleCollider2D kol;
    // Use this for initialization
    Vector3 newPosition;
    GameObject[] enemyInRange = new GameObject[30];
    Animator explosion;
    SpriteRenderer currentSprite;
    void Start()
    {
        newPosition = transform.position;
        explosion = GetComponent<Animator>();
        currentSprite = GetComponent<SpriteRenderer>();
        // explosion.Stop();
        GameObject.FindGameObjectWithTag("BombAbbilityProgress").GetComponent<ProgressBarBomb>().startPoints = numberOfExplosion;
        gameObject.SetActive(false);
        kol = GetComponent<CircleCollider2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
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

        if (numberOfExplosion < 0)
        {
            GameObject button = GameObject.FindGameObjectWithTag("BombAbbility");

            button.SetActive(false);
            //Destroy(gameObject);
        }
        if (enemysOnBomb.Count != 0 && currentSprite.sprite.name == "006")
        {
            Damage();
            print("enemyOnBomb: " + enemysOnBomb.Count.ToString());
            enemysOnBomb = new List<GameObject>();
        }
        //if (enemysOnBomb.Count!=0) print("enemyOnBomb: " + enemysOnBomb.Count.ToString());
        //print(firstClick.ToString() + "<--firstclkick");


    }
    bool firstClick = false;
    public void ActiveBomb()
    {

        if (!firstClick && numberOfExplosion > 0)
        {

            firstClick = true;
            isActive = true;
            gameObject.SetActive(true);
            kol.enabled = false;
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
    bool firstClickAfterActive = false;
    void DropBomb()
    {
        if (isActive)
        {
            if (Input.GetMouseButtonDown(0) && !explosion.GetBool("explosion") && !firstClickAfterActive)
            {
                kol.enabled = true;
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
    List<GameObject> enemysOnBomb = new List<GameObject>();
    void OnTriggerStay2D(Collider2D coll)
    {
        //print("collision with tag: " + coll.gameObject.tag + "  sprite: " + currentSprite.sprite.name);
        if (coll.gameObject.tag == "Enemy")
        {
            if (coll.gameObject.GetComponent<Rigidbody2D>().velocity == new Vector2(0.0f, 0.0f))
            {
                if (!enemysOnBomb.Contains(coll.gameObject))
                {
                    enemysOnBomb.Add(coll.gameObject);
                    //print(coll.gameObject.tag);
                    //print("dodano enemy");
                }
            }
        }

        if (true)
        {

            if ((currentSprite.sprite.name == "005" || currentSprite.sprite.name == "004") && coll.gameObject.tag == "Enemy")
            {

                if (!enemysOnBomb.Contains(coll.gameObject))
                {
                    enemysOnBomb.Add(coll.gameObject);
                    //print(coll.gameObject.tag);
                    //print("dodano enemy");
                }

            }
        }


    }

    void Damage()
    {
        print(enemysOnBomb.Count);
        foreach (GameObject enem in enemysOnBomb)
        {
            if (enem.GetComponent<EnemyMove>() == null) enem.GetComponent<EnemyMoveEnemy3>().damage(30.0f);
            else
                
                enem.GetComponent<EnemyMove>().damage(30.0f);
        }


    }



}
