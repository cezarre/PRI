using UnityEngine;
using System.Collections;

public class EnemyMoveEnemy3 : MonoBehaviour
{
    public float speed; //predkosc wroga
    Rigidbody2D player;
    bool firstPath = true;
    public float hp;
    float timer = 0;
    float preTimer = 0;
    public float distance;
    GameObject mainPlayerObject;
    public int goldOfKill = 20;
    Player mainPlayerScript;
    //public GameObject mainPlayer;
    //public GameObject spawnPoint;

    Animator anim;

    void Start()
    {

        //hp = 10;
        anim = GetComponent<Animator>();
        player = GetComponent<Rigidbody2D>();
        mainPlayerObject = GameObject.Find("Player");
        mainPlayerScript = (Player)mainPlayerObject.GetComponent(typeof(Player));




    }



    public void damage(float d)
    {
        hp -= d;
        if (hp <= 0)
        {
            mainPlayerScript.addGold(goldOfKill);
            mainPlayerScript.numberOfEnemy--;
            Destroy(gameObject);
        }
    }
    public void EndPointReached()
    {
        Debug.Log("enemy reached end point");
        mainPlayerScript.decresseHp(1);
        mainPlayerScript.numberOfEnemy--;
        Destroy(gameObject);

    }
    void FixedUpdate()
    {
        ChangeDirection();
    }

    // Update is called once per frame
    void Update()
    {
            timer += Time.deltaTime;
            distance += (timer - preTimer) * speed;
            preTimer = timer;
    }

    void OnTriggerEnter2D(Collider2D col)

    {


        //player = GetComponent<Rigidbody2D> ();
        //Debug.Log("Something has entered this zone."+ col.gameObject.tag);

        if (col.gameObject.tag == "Enemy" && col.gameObject.GetComponent<EnemyMove>().wall != true && player.velocity != (new Vector2(0, 0f)))
        {
            //print("speedup");
            col.gameObject.GetComponent<EnemyMove>().SpeedUP();
        }
        //player = GetComponent<Rigidbody2D> ();
        //Debug.Log("Something has entered this zone."+ col.gameObject.tag);

        if (firstPath)
        {
            firstPath = false;
            //pierwsze wejscie na sciezke
            /*if (col.gameObject.tag == "RTLTR" || col.gameObject.tag == "RTUTR" || col.gameObject.tag == "RTDTR") {

                player.velocity = (new Vector2 (-(speed), 0f));


            }else
            if (col.gameObject.tag == "UTDTU" || col.gameObject.tag == "UTLTU" || col.gameObject.tag == "UTRTU" ) {

                player.velocity = (new Vector2 (0f, -speed));

            }else
            if (col.gameObject.tag == "DTUTD" || col.gameObject.tag == "DTLTD" || col.gameObject.tag == "DTRTD") {

                player.velocity = (new Vector2 (0f, speed));

            }else
            if (col.gameObject.tag == "LTDTL" || col.gameObject.tag == "LTUTL" || col.gameObject.tag == "LTRTL") {

                player.velocity = (new Vector2 (speed, 0f));

            }
            */
        }
        else
        {

            //zakrety
            if (col.gameObject.tag == "UTLTL" || col.gameObject.tag == "DTLTL")
            {

                player.velocity = (new Vector2(-speed, 0f));

            }
            else

            if (col.gameObject.tag == "UTRTR" || col.gameObject.tag == "DTRTR")
            {

                player.velocity = (new Vector2(speed, 0f));


            }
            else
            if (col.gameObject.tag == "LTUTU" || col.gameObject.tag == "RTUTU")
            {

                player.velocity = (new Vector2(0f, speed));



            }
            else
            if (col.gameObject.tag == "LTDTD" || col.gameObject.tag == "RTDTD")
            {

                player.velocity = (new Vector2(0f, -speed));


            }
        }
    }
    void ChangeDirection()
    {

        //player = GetComponent<Rigidbody2D> ();
        if (player.velocity.y < 0)
        { //to down
          //animation["animation"].time = 0;
          //anim.Stop();
            anim.SetInteger("Direction", 1);
        }
        else
            if (player.velocity.y > 0)
        {//to up
            anim.SetInteger("Direction", 3);
        }
        else
            if (player.velocity.x < 0)
        { //to left
            anim.SetInteger("Direction", 0);
        }
        else
            if (player.velocity.x > 0)
        {//to right
            anim.SetInteger("Direction", 2);
        }
        //Debug.Log (anim.GetInteger("Direction").ToString ());

    }

    public void WallSpeedZero()
    {
        player.velocity = (new Vector2(0, 0f));
    }
    public void WallSpeedNormal()
    {
        int direction = anim.GetInteger("Direction");

        if (direction == 0)
        {
            player.velocity = (new Vector2(-speed, 0f));
        }
        else
            if (direction == 2)
        {

            player.velocity = (new Vector2(speed, 0f));
        }
        else
            if (direction == 3)
        {
            player.velocity = (new Vector2(0f, speed));

        }
        else
            if (direction == 1)
        {
            player.velocity = (new Vector2(0f, -speed));
        }

    }


}
