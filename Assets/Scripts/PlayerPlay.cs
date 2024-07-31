using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;    


public class PlayerPlay : MonoBehaviour
{
//    Timer timer;
   private TMP_Text MasofaText;
   public GameObject wallEnd;
   int WallMasofa;
   public Selectable CurrentSelectable;
    public GameObject PanelTop, PanelMain;

    void Awake()
    {
        if (PlayerPrefs.HasKey("ply_x"))
        {
            GameObject.Find("FP1").transform.position = new Vector3(PlayerPrefs.GetFloat("ply_x"), PlayerPrefs.GetFloat("ply_y"), PlayerPrefs.GetFloat("ply_z"));

        }
    }
    // Update is called once per frame
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        GameObject.Find("AlertText").gameObject.SetActive(false);
        GameObject.Find("HandIcon").gameObject.SetActive(false);
        PanelTop.gameObject.SetActive(false);
        PanelMain.gameObject.SetActive(false);
        WallMasofa = 150;
        if(GameObject.Find("FP1").transform.position.z>-13f)
        {
            GameObject.Find("DressD").gameObject.SetActive(false);
            GameObject.Find("Collider").gameObject.SetActive(false);
            GameObject.Find("AlertText").gameObject.SetActive(false);
        }
        //PlayerPrefs.DeleteAll();
    }
    
    void FixedUpdate()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        //Ray ray1 = Camera .main.ScreenPointToRay(Input.GetTouch(0).position);
        Debug.DrawRay(transform.position, transform.forward*100f, Color.yellow);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Selectable selectable = hit.collider.gameObject.GetComponent<Selectable>();
            if (selectable)
            {
                if(CurrentSelectable && CurrentSelectable != selectable)
                {
                    CurrentSelectable.DiSelect();
          
                }
                CurrentSelectable = selectable;
                
                selectable.Select();
                if (Input.GetKeyDown(KeyCode.Mouse0) && hit.collider.tag == "Desktop")
                {
                    PlayerPrefs.SetFloat("ply_x", GameObject.Find("FP1").transform.position.x);
                    PlayerPrefs.SetFloat("ply_y", GameObject.Find("FP1").transform.position.y);
                    PlayerPrefs.SetFloat("ply_z", GameObject.Find("FP1").transform.position.z);
                    PlayerPrefs.Save();
                    SceneManager.LoadScene("Document");
                }
               if(Input.GetKeyDown(KeyCode.Mouse0) && hit.collider.name == "DressD")
                {
                    GameObject.Find("DressD").gameObject.SetActive(false);
                    GameObject.Find("Collider").gameObject.SetActive(false);
                    GameObject.Find("AlertText").gameObject.SetActive(false);
                }
                
                
                if (Input.GetKeyDown(KeyCode.Mouse0) && hit.collider.tag == "RightGet")
                {
                    //if (WallMasofa >= 0 && WallMasofa <= 150)
                    WallMasofa = WallMasofa + 4;
                    if (WallMasofa > 150)
                    {
                        WallMasofa = 150;
                        MasofaText = GameObject.Find("Masofa").GetComponent<TMP_Text>();
                        MasofaText.text = WallMasofa + " sm";
                        Debug.Log(WallMasofa);
                    }
                    else
                    if (WallMasofa < 0)
                    {
                        WallMasofa = 0;
                        MasofaText = GameObject.Find("Masofa").GetComponent<TMP_Text>();
                        MasofaText.text = WallMasofa + " sm";
                        Debug.Log(WallMasofa);
                    }
                    else
                    if (WallMasofa >= 0 && WallMasofa <= 150)
                    {
                        MasofaText = GameObject.Find("Masofa").GetComponent<TMP_Text>();
                        MasofaText.text = WallMasofa + " sm";
                        Debug.Log(WallMasofa);
                        wallEnd = GameObject.Find("w");
                        var wallPos = wallEnd.transform.position;
                        wallEnd.transform.position = new Vector3(wallPos.x, wallPos.y, wallPos.z += 0.3f);
                    }
                }
                if (Input.GetKeyDown(KeyCode.Mouse0) && hit.collider.tag == "LeftGet")
                {
                    WallMasofa = WallMasofa - 4;
                    if (WallMasofa > 150)
                    {
                        WallMasofa = 150;
                        MasofaText = GameObject.Find("Masofa").GetComponent<TMP_Text>();
                        MasofaText.text = WallMasofa + " sm";
                        Debug.Log(WallMasofa);
                    }
                    else
                    if (WallMasofa < 0)
                    {
                        WallMasofa = 0;
                        MasofaText = GameObject.Find("Masofa").GetComponent<TMP_Text>();
                        MasofaText.text = WallMasofa + " sm";
                        Debug.Log(WallMasofa);
                    }
                    else
                    if (WallMasofa >= 0 && WallMasofa <= 150)
                    {
                        MasofaText = GameObject.Find("Masofa").GetComponent<TMP_Text>();
                        MasofaText.text = WallMasofa + " sm";
                        Debug.Log(WallMasofa);
                        wallEnd = GameObject.Find("w");
                        var wallPos = wallEnd.transform.position;
                        wallEnd.transform.position = new Vector3(wallPos.x, wallPos.y, wallPos.z -= 0.3f);
                    }
                }
                if (Input.GetKeyDown(KeyCode.Mouse0) && hit.collider.tag == "CheckAnswers")
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.Confined;
                    PanelTop.gameObject.SetActive(true);
                    PanelMain.gameObject.SetActive(true);
                }
                if (Input.GetKeyDown(KeyCode.Mouse0) && hit.collider.tag == "ToMain")
                {
                    
                    SceneManager.LoadScene("MainScene");
                    
                }


            }
            else
            {
                if(CurrentSelectable)
                {
                    CurrentSelectable.DiSelect();
                    CurrentSelectable = null;
                }
            }

            //hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        }
        else
        {
            if(CurrentSelectable)
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
