using UnityEngine;
using System.Collections;

public class Logo : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //StartCoroutine(WaitFor3Seconds());
        //Application.LoadLevel("Help");
	}

    IEnumerator WaitFor3Seconds()
    {    
        yield return new WaitForSeconds(3);
		if (PlayerPrefs.GetInt ("PlayerProgress") > 1) {
			Application.LoadLevel ("Menu");
		} else 
		{
			Application.LoadLevel("Help");
		}
    }

    // Update is called once per frame
    void Update () {
        if(Mathf.RoundToInt(transform.eulerAngles.y)==0 || Mathf.RoundToInt(transform.eulerAngles.y) == 360)
        {
            StartCoroutine(WaitFor3Seconds());
			if (transform.lossyScale.x < 2)
				transform.localScale = new Vector2 (transform.lossyScale.x + 0.0015f, transform.lossyScale.y + 0.0015f);
			//else {
			//	Application.LoadLevel("Help");
			//}
        }
        else
        {
            //transform.localScale = new Vector3(transform.lossyScale.x + 0.001f, transform.lossyScale.y + 0.001f, transform.lossyScale.z);
            transform.Rotate(new Vector3(transform.rotation.x + 2f, transform.rotation.y + 2f, transform.rotation.z + 2f));
        }
	}
}
