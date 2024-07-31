using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class FourSceneScript : MonoBehaviour
{
    public Selectable CurrentS;
    public static int LastCircuitScene = 0;
    private bool isMaximized = false;
    float xPos, yPos, zPos;
    string ActiveScene;
    void Awake()
    {
        if (PlayerPrefs.HasKey("ply_x"))
        {
            GameObject.Find("FP1").transform.position = new Vector3(PlayerPrefs.GetFloat("ply_x"), PlayerPrefs.GetFloat("ply_y"), PlayerPrefs.GetFloat("ply_z"));
        }
    }

    void Start()
    {
        
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        ActiveScene = SceneManager.GetActiveScene().name;
        GameObject.Find("AlertText").gameObject.SetActive(false);
        GameObject.Find("HandIcon").gameObject.SetActive(false);
        
        if (ActiveScene == "LabThird")
        {
            Debug.Log("Third");
            if (GameObject.Find("FP1").transform.position.x >  1576f)
            {
                GameObject.Find("DressD").gameObject.SetActive(false);
                GameObject.Find("Collider").gameObject.SetActive(false);
                GameObject.Find("AlertText").gameObject.SetActive(false);
            }
            if (ForCircuit.sendScene31 == 1)
            {
                Debug.Log("Completed31");
                GameObject.Find("BatteryFirst").transform.position = new Vector3(1547.373f, 8.944f, -274.124f);
                GameObject.Find("AmpermeterFirst").transform.position = new Vector3(1546.299f, 8.971757f, -272.8076f);
                GameObject.Find("VoltmeterFirst").transform.position = new Vector3(1547.366f, 8.959757f, -271.809f);
                GameObject.Find("LightFirst").transform.position = new Vector3(1547.418f, 9.013152f, -268.5594f);
            
                GameObject.Find("BatteryFirst").transform.rotation = Quaternion.Euler(0, 0, 90);
                GameObject.Find("AmpermeterFirst").transform.rotation = Quaternion.Euler(-90, 0, 90);
                GameObject.Find("VoltmeterFirst").transform.rotation = Quaternion.Euler(-90, 0, 90);
                GameObject.Find("LightFirst").transform.rotation = Quaternion.Euler(0, 0, 0);
            
                GameObject.Find("LightFirst").gameObject.transform.Find("Light").gameObject.SetActive(true);
                GameObject.Find("AmpermeterFirst").gameObject.transform.Find("indicator").GetComponent<TMP_Text>().text = "0.5 A";
                GameObject.Find("VoltmeterFirst").gameObject.transform.Find("indicator").GetComponent<TMP_Text>().text = "4.0 V";
            }
            if (ForCircuit.sendScene32 == 1)
            {
                Debug.Log("Completed32");
                GameObject.Find("BatterySecond").transform.position = new Vector3(1554.474f, 8.97f, -253.297f);
                GameObject.Find("AmpermeterSecond").transform.position = new Vector3(1556.386f, 8.931f, -252.319f);
                GameObject.Find("VoltmeterSecond").transform.position = new Vector3(1557.894f, 8.95f, -253.37f);
                GameObject.Find("LightSecond1").transform.position = new Vector3(1560.094f, 8.941f, -253.761f);
                GameObject.Find("LightSecond2").transform.position = new Vector3(1560.058f, 8.941f, -252.876f);
            
                GameObject.Find("BatterySecond").transform.rotation = Quaternion.Euler(0, 90, 90);
                GameObject.Find("AmpermeterSecond").transform.rotation = Quaternion.Euler(-90, 0, 180);
                GameObject.Find("VoltmeterSecond").transform.rotation = Quaternion.Euler(-90, 0, 180);
                GameObject.Find("LightSecond1").transform.rotation = Quaternion.Euler(0, 29.682f, 0);
                GameObject.Find("LightSecond2").transform.rotation = Quaternion.Euler(0, 120f, 0);
            
                GameObject.Find("LightSecond1").gameObject.transform.Find("Light").gameObject.SetActive(true);
                GameObject.Find("LightSecond2").gameObject.transform.Find("Light").gameObject.SetActive(true);
                GameObject.Find("AmpermeterSecond").gameObject.transform.Find("indicator").GetComponent<TMP_Text>().text = "0.25 A";
                GameObject.Find("VoltmeterSecond").gameObject.transform.Find("indicator").GetComponent<TMP_Text>().text = "4.0 V";
            }
            if (ForCircuit.sendScene33 == 1)
            {
                Debug.Log("Completed33");
                GameObject.Find("BatteryThird").transform.position = new Vector3(1573.913f, 8.938f, -255.843f);
                GameObject.Find("AmpermeterThird").transform.position = new Vector3(1573.912f, 8.926f, -253.763f);
                GameObject.Find("AmpermeterThird2").transform.position = new Vector3(1576.599f, 8.926f, -254.4335f);
                GameObject.Find("AmpermeterThird3").transform.position = new Vector3(1578.592f, 8.926f, -254.4335f);
                GameObject.Find("VoltmeterThird").transform.position = new Vector3(1574.846f, 8.946f, -254.788f);
                GameObject.Find("LightThird1").transform.position = new Vector3(1576.655f, 8.941f, -255.142f);
                GameObject.Find("LightThird2").transform.position = new Vector3(1578.649f, 8.941f, -255.142f);

            
                GameObject.Find("BatteryThird").transform.rotation = Quaternion.Euler(0, 180, 90);
                GameObject.Find("AmpermeterThird").transform.rotation = Quaternion.Euler(-90, 0, 180);
                GameObject.Find("AmpermeterThird2").transform.rotation = Quaternion.Euler(-90, 0, 180);
                GameObject.Find("AmpermeterThird3").transform.rotation = Quaternion.Euler(-90, 0, 180);
                GameObject.Find("VoltmeterThird").transform.rotation = Quaternion.Euler(-90, 0, 180);
                GameObject.Find("LightThird1").transform.rotation = Quaternion.Euler(0, 0, 0);
                GameObject.Find("LightThird2").transform.rotation = Quaternion.Euler(0, 340f, 0);
            
                GameObject.Find("LightThird1").gameObject.transform.Find("Light").gameObject.SetActive(true);
                GameObject.Find("LightThird2").gameObject.transform.Find("Light").gameObject.SetActive(true);
                GameObject.Find("AmpermeterThird").gameObject.transform.Find("indicator").GetComponent<TMP_Text>().text = "0.5 A";
                //**************EDITED THIRD SECTION****************************
                GameObject.Find("AmpermeterThird2").gameObject.transform.Find("indicator").GetComponent<TMP_Text>().text = "0.25 A";
                GameObject.Find("AmpermeterThird3").gameObject.transform.Find("indicator").GetComponent<TMP_Text>().text = "0.25 A";
                //**************EDITED THIRD SECTION****************************
                GameObject.Find("VoltmeterThird").gameObject.transform.Find("indicator").GetComponent<TMP_Text>().text = "4.0 V";
            }
            if ((ForCircuit.sendScene31 == 1) && LastCircuitScene ==1)
            {
                GameObject.Find("FP1").transform.position = new Vector3(1550.852f, 6.916346f, -271.0565f);
            }
            else
            if ((ForCircuit.sendScene32 == 1) && LastCircuitScene == 2)
            {
                GameObject.Find("FP1").transform.position = new Vector3(1555.19f, 6.972263f, -259.26f);
            }
            else
            if ((ForCircuit.sendScene33 == 1) && LastCircuitScene == 3)
            {
                GameObject.Find("FP1").transform.position = new Vector3(1570.236f, 6.916351f, -258.5878f);
            }
            else
            if ((ForCircuit.sendScene31 == 0) && (LastCircuitScene == 1))
            {
                GameObject.Find("FP1").transform.position = new Vector3(1553.173f, 6.916348f, -271.7449f);
            }
            else
            if (ForCircuit.sendScene32 == 0 && LastCircuitScene == 2)
            {
                GameObject.Find("FP1").transform.position = new Vector3(1558.077f, 6.916351f, -261.1617f);
            }
            else
            if (ForCircuit.sendScene33 == 0 && LastCircuitScene == 3)
            {
                GameObject.Find("FP1").transform.position = new Vector3(1572.409f, 6.916349f, -261.8714f);
            }

            if (LastCircuitScene != 0)
            {
                GameObject.Find("DressD").gameObject.SetActive(false);
                GameObject.Find("Collider").gameObject.SetActive(false);
                GameObject.Find("AlertText").gameObject.SetActive(false);
            }
        }
        else
        if(ActiveScene == "LabFour")
        {
            GameObject.Find("2Green").SetActive(true);
            Debug.Log("Four");
            if (GameObject.Find("FP1").transform.position.x < 1553f)
            {
                GameObject.Find("DressD").gameObject.SetActive(false);
                GameObject.Find("Collider").gameObject.SetActive(false);
                GameObject.Find("AlertText").gameObject.SetActive(false);
            }
            if (ForCircuit2.sendScene41 == 1)
            {
                Debug.Log("Completed41");
                GameObject.Find("BatteryFirst").transform.position = new Vector3(1559.059f, 8.937f, -253.765f);
                GameObject.Find("AmpermeterFirst").transform.position = new Vector3(1560.383f, 8.956f, -252.687f);
                GameObject.Find("VoltmeterFirst").transform.position = new Vector3(1561.395f, 8.951f, -253.756f);
                GameObject.Find("RheostatFirst").transform.position = new Vector3(1564.634f, 8.91f, -253.757f);

                GameObject.Find("BatteryFirst").transform.rotation = Quaternion.Euler(0, 90, 90);
                GameObject.Find("AmpermeterFirst").transform.rotation = Quaternion.Euler(-90, 0, 180);
                GameObject.Find("VoltmeterFirst").transform.rotation = Quaternion.Euler(-90, 0, 180);
                GameObject.Find("RheostatFirst").transform.rotation = Quaternion.Euler(-90, 0, 90);

                GameObject.Find("AmpermeterFirst").gameObject.transform.Find("indicator").GetComponent<TMP_Text>().text = "0.5 A";
                GameObject.Find("VoltmeterFirst").gameObject.transform.Find("indicator").GetComponent<TMP_Text>().text = "4.0 V";
            }
            if (ForCircuit2.sendScene42 == 1)
            {
                Debug.Log("Completed42");
                GameObject.Find("BatterySecond").transform.position = new Vector3(1572.306f, 8.932f, -253.542f);
                GameObject.Find("AmpermeterSecond").transform.position = new Vector3(1574.232f, 8.964f, -252.557f);
                GameObject.Find("VoltmeterSecond").transform.position = new Vector3(1575.713f, 8.945f, -253.624f);
                GameObject.Find("RheostatSecond1").transform.position = new Vector3(1577.874f, 8.93f, -253.99f);
                GameObject.Find("RheostatSecond2").transform.position = new Vector3(1577.889f, 8.92f, -253.092f);

                GameObject.Find("BatterySecond").transform.rotation = Quaternion.Euler(0, 90, 90);
                GameObject.Find("AmpermeterSecond").transform.rotation = Quaternion.Euler(-90, 0, 180);
                GameObject.Find("VoltmeterSecond").transform.rotation = Quaternion.Euler(-90, 0, 180);
                GameObject.Find("RheostatSecond1").transform.rotation = Quaternion.Euler(0, 90, 0);
                GameObject.Find("RheostatSecond2").transform.rotation = Quaternion.Euler(0, 90, 0);

                GameObject.Find("AmpermeterSecond").gameObject.transform.Find("indicator").GetComponent<TMP_Text>().text = "0.25 A";
                GameObject.Find("VoltmeterSecond").gameObject.transform.Find("indicator").GetComponent<TMP_Text>().text = "4.0 V";
            }
            if (ForCircuit2.sendScene43 == 1)
            {
                Debug.Log("Completed43");
                GameObject.Find("BatteryThird").transform.position = new Vector3(1581.451f, 9.003f, -269.932f);
                GameObject.Find("AmpermeterThird").transform.position = new Vector3(1583.537f, 9.057f, -269.935f);
                GameObject.Find("VoltmeterThird").transform.position = new Vector3(1582.503f, 9.007f, -270.863f);
                GameObject.Find("RheostatThird1").transform.position = new Vector3(1582.492f, 9.043f, -272.61f);
                GameObject.Find("RheostatThird2").transform.position = new Vector3(1582.492f, 9.043f, -274.6121f);

                GameObject.Find("BatteryThird").transform.rotation = Quaternion.Euler(0, 90, 90);
                GameObject.Find("AmpermeterThird").transform.rotation = Quaternion.Euler(-90, 90, 180);
                GameObject.Find("VoltmeterThird").transform.rotation = Quaternion.Euler(-90, 90, 180);
                GameObject.Find("RheostatThird1").transform.rotation = Quaternion.Euler(0, 180, 0);
                GameObject.Find("RheostatThird2").transform.rotation = Quaternion.Euler(0, 180, 0);

                GameObject.Find("AmpermeterThird").gameObject.transform.Find("indicator").GetComponent<TMP_Text>().text = "1.0 A";
                GameObject.Find("VoltmeterThird").gameObject.transform.Find("indicator").GetComponent<TMP_Text>().text = "4.0 V";
            }
            if (ForCircuit2.sendScene41 == 1 && LastCircuitScene == 1)
            {
                GameObject.Find("FP1").transform.position = new Vector3(1561.238f, 6.922262f, -257.8988f);
            }
            else
            if (ForCircuit2.sendScene42 == 1 && LastCircuitScene == 2)
            {
                GameObject.Find("FP1").transform.position = new Vector3(1574.801f, 6.971263f, -258.4446f);
            }
            else
            if (ForCircuit2.sendScene43 == 1 && LastCircuitScene == 3)
            {
                GameObject.Find("FP1").transform.position = new Vector3(1576.9f, 6.916351f, -273.36f);
            }
            else
            if (ForCircuit2.sendScene41 == 0 && LastCircuitScene == 1)
            {
                GameObject.Find("FP1").transform.position = new Vector3(1560.849f, 6.916351f, -259.4605f);
            }
            else
            if (ForCircuit2.sendScene42 == 0 && LastCircuitScene == 2)
            {
                GameObject.Find("FP1").transform.position = new Vector3(1574.691f, 6.916348f, -260.1225f);
            }
            else
            if (ForCircuit2.sendScene43 == 0 && LastCircuitScene == 3)
            {
                GameObject.Find("FP1").transform.position = new Vector3(1575.495f, 6.916346f, -274.2218f);
            }
            Debug.Log("LastCircuitScene:" + LastCircuitScene);
            if (LastCircuitScene != 0)
            {
                GameObject.Find("DressD").gameObject.SetActive(false);
                GameObject.Find("Collider").gameObject.SetActive(false);
                GameObject.Find("AlertText").gameObject.SetActive(false);
            }
        }

        
        /*
        if (PlayerPrefs.HasKey("player_x"))
        {
            GameObject.Find("FP").transform.position = new Vector3(PlayerPrefs.GetFloat("player_x"), PlayerPrefs.GetFloat("player_y"), PlayerPrefs.GetFloat("player_z"));
        }
        PlayerPrefs.DeleteAll();
        */
        /*
        if (GameObject.Find("FP1").transform.position.x > 1571f)
        {
            GameObject.Find("DressD").gameObject.SetActive(false);
            GameObject.Find("Collider").gameObject.SetActive(false);
            GameObject.Find("AlertText").gameObject.SetActive(false);
        }*/
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
                    PlayerPrefs.SetFloat("ply_x", GameObject.Find("FP1").transform.position.x);
                    PlayerPrefs.SetFloat("ply_y", GameObject.Find("FP1").transform.position.y);
                    PlayerPrefs.SetFloat("ply_z", GameObject.Find("FP1").transform.position.z);
                    PlayerPrefs.Save();
                    if(ActiveScene == "LabThird")
                        SceneManager.LoadScene("Document3");
                    else
                    if(ActiveScene == "LabFour")
                        SceneManager.LoadScene("Document4");
                }
                if (Input.GetKeyDown(KeyCode.Mouse0) && hit.collider.tag == "ToMain")
                {
                    SceneManager.LoadScene("MainScene");
                }
                if (Input.GetKeyDown(KeyCode.Mouse0) && hit.collider.name == "Kontakt")
                {
                    Debug.Log("Kontakt");
                    
                    //GameObject.Find("Box001").transform.position = new Vector3(1547.3f, 8.946f, -274.1f);
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
