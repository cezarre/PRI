using UnityEngine;
using System.Collections;

public class Click : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        //print("CLICK");
        //bool isClicked = transform.parent.gameObject.GetComponent<Towers>().isClicked;

        //transform.FindChild("TowerWithBuild").transform.FindChild("Tower-UI").gameObject.SetActive(false);

        foreach (GameObject tower in GameObject.FindGameObjectsWithTag("Tower"))
        {
            tower.transform.FindChild("Tower-UI").gameObject.SetActive(false);
        }
        transform.gameObject.SetActive(false);
    }
}
