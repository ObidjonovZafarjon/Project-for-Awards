using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class ThirdSceneScript : MonoBehaviour
{

    public Selectable CurrentS;
    float xPos, yPos, zPos;
    // Update is called once per frame
    void Awake()
    {
        if (PlayerPrefs.HasKey("ply_x"))
        {
            GameObject.Find("FP2").transform.position = new Vector3(PlayerPrefs.GetFloat("ply_x"), PlayerPrefs.GetFloat("ply_y"), PlayerPrefs.GetFloat("ply_z"));
        }
        
    }

    void Start()
    {
        
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        GameObject.Find("AlertText").gameObject.SetActive(false);
        GameObject.Find("HandIcon").gameObject.SetActive(false);

        

        /*
        if (PlayerPrefs.HasKey("player_x"))
        {
            GameObject.Find("FP").transform.position = new Vector3(PlayerPrefs.GetFloat("player_x"), PlayerPrefs.GetFloat("player_y"), PlayerPrefs.GetFloat("player_z"));
        }
        PlayerPrefs.DeleteAll();
        */
        if (GameObject.Find("FP2").transform.position.x > 1571f)
        {
            GameObject.Find("DressD").gameObject.SetActive(false);
            GameObject.Find("Collider").gameObject.SetActive(false);
            GameObject.Find("AlertText").gameObject.SetActive(false);
        }
        //GameObject.Find("ConeFrame").gameObject.SetActive(true);
        //GameObject.Find("CubeFrame").gameObject.SetActive(false);
        //GameObject.Find("SphereFrame").gameObject.SetActive(false);
        //GameObject.Find("CylinderFrame").gameObject.SetActive(false);


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
                if (CurrentS && CurrentS != selectable)
                {
                    CurrentS.DiSelect();

                }
                CurrentS = selectable;

                selectable.Select();
                

                if (Input.GetKeyDown(KeyCode.Mouse0) && hit.collider.name == "DressD")
                {
                    GameObject.Find("DressD").gameObject.SetActive(false);
                    GameObject.Find("Collider").gameObject.SetActive(false);
                    GameObject.Find("AlertText").gameObject.SetActive(false);
                }
                if (Input.GetKeyDown(KeyCode.Mouse0) && hit.collider.name == "DesktopTable")
                {
                    PlayerPrefs.SetFloat("ply_x", GameObject.Find("FP2").transform.position.x);
                    PlayerPrefs.SetFloat("ply_y", GameObject.Find("FP2").transform.position.y);
                    PlayerPrefs.SetFloat("ply_z", GameObject.Find("FP2").transform.position.z);
                    PlayerPrefs.Save();
                    SceneManager.LoadScene("Document2");
                }
                if (Input.GetKeyDown(KeyCode.Mouse0) && hit.collider.tag == "ToMain")
                {
                   
                    SceneManager.LoadScene("MainScene");
                }
                if (Input.GetKeyDown(KeyCode.Mouse0) && hit.collider.name == "ToHotBtn")
                {
                    GameObject.Find("Cylinder").gameObject.GetComponent<ToHot>().hotting();
                }
                if (Input.GetKeyDown(KeyCode.Mouse0) && hit.collider.name == "ButtonP")
                {
                    GameObject.Find("kalorimetr").gameObject.transform.Find("Cylinder002").GetComponent<ToHot>().ToOpen();
                }
                if (Input.GetKeyDown(KeyCode.Mouse0) && hit.collider.name == "ButtonC")
                {
                    GameObject.Find("kalorimetr").gameObject.transform.Find("Cylinder002").GetComponent<ToHot>().ToClose();
                }
            }
            else
            {
                if (CurrentS)
                {
                    CurrentS.DiSelect();
                    CurrentS = null;
                }
            }

            //hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        }
        else
        {
            if (CurrentS)
            {
                CurrentS.DiSelect();
                CurrentS = null;
            }
        }


      
    }
}
