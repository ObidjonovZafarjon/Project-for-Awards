using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ForCoroutine : MonoBehaviour
{
    public Selectable CurrentSelectable;
    private bool isStarted = false;
   
    private TMP_Text timerText;
    public GameObject wallT;
    private int sec = 0;
    private int min = 0;
    
    void OnCollisionEnter(Collision other)
    {
        StopCoroutine(TimeFlow());
        Debug.Log("OK");
    }

    private void FixedUpdate()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * 100f, Color.yellow);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Selectable selectable = hit.collider.gameObject.GetComponent<Selectable>();
            if (selectable)
            {
                if (CurrentSelectable && CurrentSelectable != selectable)
                {
                    CurrentSelectable.DiSelect();

                }
                CurrentSelectable = selectable;

                selectable.Select();
           
                if (Input.GetKeyDown(KeyCode.Mouse0) && hit.collider.tag == "playBtn")
                {

                    //timer.StartTimer();
                    if (!isStarted)
                    {
                        timerText = GameObject.Find("timer").GetComponent<TMP_Text>();
                        StartCoroutine(TimeFlow());
                        isStarted = true;
                    }

                    wallT = GameObject.Find("wallLab");
                    Debug.Log(wallT.transform.position.x);
                    wallT.transform.position = new Vector3(76.23f, 11.22821f, -18.23395f);
                }
              
              

            }
            else
            {
                if (CurrentSelectable)
                {
                    CurrentSelectable.DiSelect();
                    CurrentSelectable = null;
                }
            }

            //hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        }
        else
        {
            if (CurrentSelectable)
            {
                CurrentSelectable.DiSelect();
                CurrentSelectable = null;
            }
        }

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
            Debug.Log(sec);

            yield return new WaitForSeconds(1);
        }
    }
}
