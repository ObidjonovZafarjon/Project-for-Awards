using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Coroutine : MonoBehaviour
{
    private bool worked;

    public Selectable CurrentSelectable;
    public GameObject forCheckCollision;
    private bool isStarted = false;

    private TMP_Text timerText;
    public GameObject wallT;
    private int sec = 0;
    private int min = 0;

    

    private void FixedUpdate()
    {
        if (GameObject.Find("ForCheckCollision").GetComponent<Text>().text == "1")
            StopCoroutine(TimeFlow());
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
                if (Input.GetKeyDown(KeyCode.Mouse0) && hit.collider.tag == "PlayBut")
                {
                    GameObject.Find("ForCheckCollision").GetComponent<Text>().text = "0";
                    if (!isStarted)
                    {
                        timerText = GameObject.Find("timer").GetComponent<TMP_Text>();
                        StartCoroutine(TimeFlow()); 
                        isStarted = true;
                    }
                    wallT = GameObject.Find("wallLab");
                    Debug.Log(wallT.transform.position.x);
                    wallT.transform.position = new Vector3(1549.129f, 11.22821f, -11.98269f);
                    wallT.transform.localScale = new Vector3(0.03376491f, 0.7427899f, 1.726809f);
                    sec = 0; min = 0;
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

    
    IEnumerator TimeFlow(bool stopped = true)
    {
        
            while (stopped)
            {
                if (GameObject.Find("ForCheckCollision").GetComponent<Text>().text != "1")
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
                else
                    yield return new WaitForSeconds(1);
            }
        
    }


}
