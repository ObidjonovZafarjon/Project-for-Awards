using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    private int sec = 0;
    private int min = 0;
    private TMP_Text timerText;
    // private int delta = 0;

    void Start()
    {
        timerText = GameObject.Find("timer").GetComponent<TMP_Text>();
        StartCoroutine(TimeFlow());

    }
    IEnumerator TimeFlow()
    {
        while (true)
        {
            if (sec == 59)
            {
                min++;
                sec = -1;
            }
            sec += 1;
            timerText.text = min.ToString("D2") + ":" + sec.ToString("D2");

            yield return new WaitForSeconds(1);
        }
    }
    /* public void StartStop(int delta)
     {
         this.delta = delta;
     }*/
    public void message()
    {
        Debug.Log("Message!");
    }

}
