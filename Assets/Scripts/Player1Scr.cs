using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class Player1Scr : MonoBehaviour
{
    
    private TMP_Text MasofaText;
    public GameObject wallEnd;
    int WallMasofa;
    public Selectable CurrentSelectable;

    // Update is called once per frame
    
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        GameObject.Find("AlertText").gameObject.SetActive(false);
        GameObject.Find("DressText").gameObject.SetActive(false);
        GameObject.Find("HandIcon").gameObject.SetActive(false);
        WallMasofa = 150;
    }

    void FixedUpdate()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        //Ray ray1 = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
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
                if (Input.GetKeyDown(KeyCode.Mouse0) && hit.collider.tag == "Desktop")
                {
                    SceneManager.LoadScene("Document");
                }
                if (Input.GetKeyDown(KeyCode.Mouse0) && hit.collider.name == "DressD")
                {
                    GameObject.Find("DressD").gameObject.SetActive(false);
                    GameObject.Find("Collider").gameObject.SetActive(false);
                    GameObject.Find("AlertText").gameObject.SetActive(false);
                    GameObject.Find("DressText").gameObject.SetActive(false);
                }


                if (Input.GetKeyDown(KeyCode.Mouse0) && hit.collider.tag == "LeftGet" && WallMasofa >= 0 && WallMasofa <= 150)
                {
                    WallMasofa = WallMasofa - 4;
                    MasofaText = GameObject.Find("Masofa").GetComponent<TMP_Text>();
                    MasofaText.text = WallMasofa + " sm";
                    Debug.Log(WallMasofa);
                    wallEnd = GameObject.Find("w");
                    var wallPos = wallEnd.transform.position;
                    wallEnd.transform.position = new Vector3(wallPos.x, wallPos.y, wallPos.z += 0.3f);
                }
                if (Input.GetKeyDown(KeyCode.Mouse0) && hit.collider.tag == "RightGet" && WallMasofa >= 0 && WallMasofa <= 150)
                {

                    WallMasofa = WallMasofa + 4;
                    Debug.Log(WallMasofa);
                    MasofaText = GameObject.Find("Masofa").GetComponent<TMP_Text>();
                    MasofaText.text = WallMasofa + " sm";
                    wallEnd = GameObject.Find("w");
                    var wallPos = wallEnd.transform.position;
                    wallEnd.transform.position = new Vector3(wallPos.x, wallPos.y, wallPos.z -= 0.3f);
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




    public void desktopScene()
    {
        SceneManager.LoadScene("Document");
    }
}
