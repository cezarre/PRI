using UnityEngine;
using System.Collections;

public class EnemyMoveEnemy3 : MonoBehaviour
{
    public float speed; //predkosc wroga
    Rigidbody2D player;
    bool firstPath = true;
    public float hp;
    float timer = 0;
    public float distance;
    GameObject mainPlayerObject;
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
            mainPlayerScript.addGold(20);
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
        distance = timer * speed;
    }
    void OnTriggerEnter2D(Collider2D col)

    {


        //player = GetComponent<Rigidbody2D> ();
        //Debug.Log("Something has entered this zone."+ col.gameObject.tag);
        if (col.gameObject.tag=="enemy")
        {
            col.gameObject.GetComponent<EnemyMove>().SpeedUP();
        }
        if (firstPath)
        {
            firstPath = false;
            //pierwsze wejscie na sciezke
            if (col.gameObject.tag == "RTLTR" || col.gameObject.tag == "RTUTR" || col.gameObject.tag == "RTDTR")
            {

                player.AddForce(new Vector2(-(speed), 0f));


            }
            else
            if (col.gameObject.tag == "UTDTU" || col.gameObject.tag == "UTLTU" || col.gameObject.tag == "UTRTU")
            {

                player.AddForce(new Vector2(0f, -speed));

            }
            else
            if (col.gameObject.tag == "DTUTD" || col.gameObject.tag == "DTLTD" || col.gameObject.tag == "DTRTD")
            {

                player.AddForce(new Vector2(0f, speed));

            }
            else
            if (col.gameObject.tag == "LTDTL" || col.gameObject.tag == "LTUTL" || col.gameObject.tag == "LTRTL")
            {

                player.AddForce(new Vector2(speed, 0f));

            }

        }
        else
        {

            //zakrety
            if (col.gameObject.tag == "UTLTL" || col.gameObject.tag == "LTUTU")
            {

                player.AddForce(new Vector2(-speed, speed));

            }
            else

            if (col.gameObject.tag == "UTRTR" || col.gameObject.tag == "RTUTU")
            {

                player.AddForce(new Vector2(speed, speed));


            }
            else
            if (col.gameObject.tag == "DTLTL" || col.gameObject.tag == "LTDTD")
            {

                player.AddForce(new Vector2(-speed, -speed));



            }
            else
            if (col.gameObject.tag == "DTRTR" || col.gameObject.tag == "RTDTD")
            {

                player.AddForce(new Vector2(speed, -speed));


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
   
}
