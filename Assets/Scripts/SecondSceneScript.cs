using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class SecondSceneScript : MonoBehaviour
{
    public Text ForMenzurka;

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
      //  Debug.Log(ForCircuit.sendScene31);
        GameObject.Find("AlertText").gameObject.SetActive(false);
        GameObject.Find("HandIcon").gameObject.SetActive(false);
        ForMenzurka.gameObject.SetActive(false);
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
                
                for(int i=0; i<4; i++)
                {
                    if(WaterDrag.chuckedArray[i]==true)
                    {

                        if (selectable.gameObject.name != WaterDrag.fourE[i])
                        {
                            ForMenzurka.gameObject.SetActive(true);
                        }
                        else
                            ForMenzurka.gameObject.SetActive(false);
                    }
                }
                

                //                Debug.Log(selectable);

                /*
                if (hit.collider.name == "Cube")
                {
                    GameObject.Find("CubeFrame").gameObject.SetActive(true);
                }
                if (hit.collider.name == "Cylinder")
                {
                    GameObject.Find("CylinderFrame").gameObject.SetActive(true);
                }
                if (hit.collider.name == "Sphere")
                {
                    GameObject.Find("SphereFrame").gameObject.SetActive(true);
                }
                if (hit.collider.name == "Cone")
                {
                    GameObject.Find("ConeFrame").gameObject.SetActive(true);
                }*/

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
            }
            else
            {
                if (CurrentS)
                {
                    CurrentS.DiSelect();
                    CurrentS = null;
                    ForMenzurka.gameObject.SetActive(false);
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


        //*****************STAYED ELEMENTS*****************************
        if (WaterDrag.chucked == true)
        {
            
            xPos = GameObject.Find(GameObject.Find("Menzurka").gameObject.transform.Find("Cylinder").gameObject.tag).gameObject.transform.position.x;
            yPos = GameObject.Find(GameObject.Find("Menzurka").gameObject.transform.Find("Cylinder").gameObject.tag).gameObject.transform.position.y;
            zPos = GameObject.Find(GameObject.Find("Menzurka").gameObject.transform.Find("Cylinder").gameObject.tag).gameObject.transform.position.z;
            //Debug.Log(xPos + "|" + zPos);
            Debug.Log(GameObject.Find(GameObject.Find("Menzurka").gameObject.transform.Find("Cylinder").gameObject.tag).gameObject.name);
            if (xPos <= 1556f || xPos >= 1559f || zPos <= -259f || zPos >= -256f)
            {
                //GameObject.Find("Menzurka").gameObject.transform.Find("Cylinder").GetComponent<WaterDrag>();
                StartCoroutine(GameObject.Find("Menzurka").gameObject.transform.Find("Cylinder").GetComponent<WaterDrag>().MinScale());
                // GameObject.Find("Menzurka").gameObject.transform.Find("Cylinder").transform.localScale = new Vector3(1, 0.31f, 1);
                GameObject.Find(GameObject.Find("Menzurka").gameObject.transform.Find("Cylinder").gameObject.tag).GetComponent<Rigidbody>().drag = 0;
                GameObject.Find("NumberWater").gameObject.transform.Find("Masofa").GetComponent<TMP_Text>().text = "30";

            }
        }
        


        //*****************STAYED ELEMENTS*****************************
    }
}
