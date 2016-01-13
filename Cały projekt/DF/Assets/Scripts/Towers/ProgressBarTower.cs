using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ProgressBarTower : MonoBehaviour
{ 
    int secondToNext;
    Image progressBar;
    float iterator;
    public bool tapped;

    void Start()
    {

        secondToNext = transform.parent.parent.GetComponent<Towers>().secondsToNextTower;

        progressBar = GetComponent<Image>();
        progressBar.fillAmount = 0;
        iterator = 0;
        //print("EMITERSELECT");
    }

    void Update()
    {
        //print(secondToNext);
        if (tapped)
        {
            iterator += 1.0f / secondToNext * Time.deltaTime;
            progressBar.fillAmount = iterator;




            if (iterator >= 1)
            {
                tapped = false;
                
                transform.parent.parent.GetComponent<Towers>().BuildWaitEnd();
                transform.gameObject.SetActive(false);
            }
        }

        
    }


    public void MyStart()
    {
        tapped = true;
        Start();
        
    }






}
