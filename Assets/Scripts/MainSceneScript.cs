using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class MainSceneScript : MonoBehaviour
{
    public Selectable CurrentS;
    public TMP_Text InfoNameText;
    public TMP_Text InfoJobText;
    public GameObject LaserTeacher;
    // Update is called once per frame
    void Awake()
    {
        
    }

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        InfoNameText.text = RegistryScript.UserName;
        InfoJobText.text = RegistryScript.StatusName + " | " + RegistryScript.ClassName;
        if (RegistryScript.StatusName == "O'qituvchi")
        {
            LaserTeacher.gameObject.SetActive(true);
        }
        GameObject.Find("AlertText").gameObject.SetActive(false);
        GameObject.Find("HandIcon").gameObject.SetActive(false);
        if (PlayerPrefs.HasKey("player_x"))
        {
            GameObject.Find("FP").transform.position = new Vector3(PlayerPrefs.GetFloat("player_x"), PlayerPrefs.GetFloat("player_y"), PlayerPrefs.GetFloat("player_z"));
        }
        PlayerPrefs.DeleteAll();
        

    }

    void FixedUpdate()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        //Ray ray1 = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        Debug.DrawRay(transform.position, transform.forward * 10, Color.yellow);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 20f))
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
                if (Input.GetKeyDown(KeyCode.Mouse0) && hit.collider.tag == "DoorFirst")
                {
                    PlayerPrefs.SetFloat("player_x", GameObject.Find("FP").transform.position.x);
                    PlayerPrefs.SetFloat("player_y", GameObject.Find("FP").transform.position.y);
                    PlayerPrefs.SetFloat("player_z", GameObject.Find("FP").transform.position.z);
                    PlayerPrefs.Save();
                    SceneManager.LoadScene("LabFirst");
                }
                else
                if (Input.GetKeyDown(KeyCode.Mouse0) && hit.collider.tag == "DoorSecond")
                {
                    PlayerPrefs.SetFloat("player_x", GameObject.Find("FP").transform.position.x);
                    PlayerPrefs.SetFloat("player_y", GameObject.Find("FP").transform.position.y);
                    PlayerPrefs.SetFloat("player_z", GameObject.Find("FP").transform.position.z);
                    PlayerPrefs.Save();
                    SceneManager.LoadScene("LabSecond");
                }
                else
                if(Input.GetKeyDown(KeyCode.Mouse0) && hit.collider.tag == "DoorThird")
                {
                    PlayerPrefs.SetFloat("player_x", GameObject.Find("FP").transform.position.x);
                    PlayerPrefs.SetFloat("player_y", GameObject.Find("FP").transform.position.y);
                    PlayerPrefs.SetFloat("player_z", GameObject.Find("FP").transform.position.z);
                    PlayerPrefs.Save();
                    SceneManager.LoadScene("LabThird");
                }
                else
                if (Input.GetKeyDown(KeyCode.Mouse0) && hit.collider.tag == "DoorFour")
                {
                    PlayerPrefs.SetFloat("player_x", GameObject.Find("FP").transform.position.x);
                    PlayerPrefs.SetFloat("player_y", GameObject.Find("FP").transform.position.y);
                    PlayerPrefs.SetFloat("player_z", GameObject.Find("FP").transform.position.z);
                    PlayerPrefs.Save();
                    SceneManager.LoadScene("LabFour");
                }
                else
                if (Input.GetKeyDown(KeyCode.Mouse0) && hit.collider.tag == "DoorFive")
                {
                    PlayerPrefs.SetFloat("player_x", GameObject.Find("FP").transform.position.x);
                    PlayerPrefs.SetFloat("player_y", GameObject.Find("FP").transform.position.y);
                    PlayerPrefs.SetFloat("player_z", GameObject.Find("FP").transform.position.z);
                    PlayerPrefs.Save();
                    SceneManager.LoadScene("LabFive");
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
