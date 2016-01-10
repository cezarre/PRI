using UnityEngine;
using System.Collections;

public class LostEnemyCatcher : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame

    void OnTriggerEnter2D(Collider2D col)

    {
        print(col.tag);
        if (col.tag == "Enemy") Destroy(col.gameObject);
    }
}
