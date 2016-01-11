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
        print("CLICK");
        bool isClicked = transform.parent.gameObject.GetComponent<Towers>().isClicked;

        transform.parent.transform.FindChild("Tower-UI").gameObject.SetActive(false);

    }
}
