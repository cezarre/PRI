using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Wall : MonoBehaviour
{
    public int secondToLoadNewWall = 15;
    public int secondToDestroy = 5;
    public bool isActive = false;
    List<GameObject> enemysOnWall = new List<GameObject>();
    BoxCollider2D kol;
    public bool abilityBlocked = false;
    //kol.enabled = false;



    // Use this for initialization
    void Start()
    {
        //Invoke("DestroyThisWall", 5);
        kol = GetComponent<BoxCollider2D>();
    }
    //void DestroyThisWall()
   // {
    //    enemysOnWall = new List<GameObject>();
    //    Destroy(gameObject);
    //}

    // Update is called once per frame
    void Update()
    {
        //print("isActive: " + isActive.ToString() + " firstClickOnButton: " + firstClickOnButton.ToString() + " firstClickAfterSelect: " + firstClickAfterSelect.ToString());
        WallFollowMouse();
        DropWall();
        //print("enemy on Wall: " + enemysOnWall.Count.ToString());
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            enemysOnWall.Add(coll.gameObject);
            if (coll.gameObject.GetComponent<EnemyMove>() == null)
                coll.gameObject.GetComponent<EnemyMoveEnemy3>().WallSpeedZero();
            else
                coll.gameObject.GetComponent<EnemyMove>().WallSpeedZero();

        }


    }

    bool firstClickOnButton = false;
    public void ActiveWall()
    {
        if (!dropped && numberOfWall > 0 && !abilityBlocked)
        {
            if (!firstClickOnButton)
            {
                isActive = true;
                firstClickOnButton = true;
                gameObject.SetActive(true);
                kol.enabled = false;
                enemysOnWall = new List<GameObject>();
            }
            else
            {

                kol.enabled = false;
                firstClickOnButton = false;
                isActive = false;
                fakeFalseActive();
            }
        }


    }


    void WallFollowMouse()
    {
        if (isActive)
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
    public int numberOfWall = 3;
    bool firstClickAfterSelect = false;
    void DropWall()
    {
        if (isActive)
        {
            if (Input.GetMouseButtonDown(0) && !firstClickAfterSelect && numberOfWall > 0)
            {
                dropped = true;
                kol.enabled = true;
                firstClickAfterSelect = true;
                float x = Input.mousePosition.x;
                float y = Input.mousePosition.y;
                float z = Input.mousePosition.z;
                Vector3 tans = Camera.main.ScreenToWorldPoint(new Vector3(x, y, 0));
                //print(tans.ToString());
                tans = new Vector3(tans.x, tans.y, 0);
                transform.position = tans;

                isActive = false;

                numberOfWall--;
                Invoke("DeleteWall", secondToDestroy);

            }
        }
    }
    public bool dropped = false;
    bool delete = false;
    void DeleteWall()
    {
        for (int i = 0; i < enemysOnWall.Count; i++)
        {
            //)
            if (enemysOnWall[i] == null)
            {
                enemysOnWall.RemoveAt(i);
                i--;
            }
            else
            {
                if (enemysOnWall[i].GetComponent<EnemyMove>() == null)
                    enemysOnWall[i].GetComponent<EnemyMoveEnemy3>().WallSpeedNormal();
                else
                    enemysOnWall[i].GetComponent<EnemyMove>().WallSpeedNormal();
            }

        }
        dropped = false;
        //print("wall delete");
        delete = true;
        kol.enabled = false;
        firstClickOnButton = false;
        isActive = false;
        firstClickAfterSelect = false;
        fakeFalseActive();
    }


    void fakeFalseActive()
    {
        transform.position = new Vector2(-1000, -1000);
        kol.enabled = false;
        firstClickOnButton = false;
        isActive = false;
        firstClickAfterSelect = false;
    }


}
