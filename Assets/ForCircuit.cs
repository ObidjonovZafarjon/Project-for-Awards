using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEditor;
using UnityEngine.SceneManagement;
using TMPro;







public class ForCircuit : MonoBehaviour, IPointerClickHandler
{
    private string ActiveSceneName;
    private bool objSelected = false;
    private bool pinSelected = false;
    private GameObject gName;
    private GameObject delObject;
    string tempName;
    private Vector2 coor1 = new Vector2(0f, 0f);
    private Vector2 coor2 = new Vector2(0f, 0f);
    public GameObject Ampermeter;
    public GameObject Voltmeter;
    public GameObject BatteryGor;
    public GameObject BatteryVer;
    public GameObject Lamp;
    public Canvas canvasParent;
    float elementCount = 0;
    
    float maxElementCount = 4;
    private GameObject newPref;
    public static int sendScene31 = 0;
    public static int sendScene32 = 0;
    public static int sendScene33 = 0;
    private GameObject panelExit;

    void Start()
    {
        ActiveSceneName = SceneManager.GetActiveScene().name;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        GameObject.Find("PanelExit").gameObject.SetActive(false);
        panelExit = GameObject.Find("GameHandler");
        panelExit = panelExit.transform.GetChild(0).gameObject;
        panelExit = panelExit.transform.GetChild(0).gameObject;
        panelExit = panelExit.gameObject.transform.Find("PanelExit").gameObject;

        if (ActiveSceneName == "CircuitScene31")
        {
            maxElementCount = 4;
        }
        else
        if (ActiveSceneName == "CircuitScene32")
        {
            maxElementCount = 5;
        }
        else
        if (ActiveSceneName == "CircuitScene33")
        {
            maxElementCount = 7;
        }

    }
    public void onYesBtn()
    {
        if(ActiveSceneName.Substring(0,13) == "CircuitScene3")
            SceneManager.LoadScene("LabThird");
        else
        if (ActiveSceneName.Substring(0, 13) == "CircuitScene4")
            SceneManager.LoadScene("LabFour");

    }

    public void onNoBtn()
    {
        panelExit.SetActive(false);
    }
    public void onClickBtn()
    {
        panelExit.SetActive(true);
        if (elementCount == maxElementCount)
        {
            panelExit.transform.Find("Text").GetComponent<UnityEngine.UI.Text>().text = "Tabriklaymiz! Topshiriq to'g'ri bajarildi!\nLaboratoriya xonasiga qaytishni xohlaysizmi?";
            if (ActiveSceneName == "CircuitScene31")
            {
                sendScene31 = 1;
                FourSceneScript.LastCircuitScene = 1;
            }
            else
            if (ActiveSceneName == "CircuitScene32")
            {
                sendScene32 = 1;
                FourSceneScript.LastCircuitScene = 2;
            }
            else
            if (ActiveSceneName == "CircuitScene33")
            {
                sendScene33 = 1;
                FourSceneScript.LastCircuitScene = 3;
            }
        }
        else
        {
            panelExit.transform.Find("Text").GetComponent<UnityEngine.UI.Text>().text = "Topshiriq bajarilmadi!\nLaboratoriya xonasiga qaytishni xohlaysizmi?";
            if (ActiveSceneName == "CircuitScene31")
            {
                sendScene31 = 0;
                FourSceneScript.LastCircuitScene = 1;
            }
            else
            if (ActiveSceneName == "CircuitScene32")
            {
                sendScene32 = 0;
                FourSceneScript.LastCircuitScene = 2;
            }
            else
            if (ActiveSceneName == "CircuitScene33")
            {
                sendScene33 = 0;
                FourSceneScript.LastCircuitScene = 3;
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        panelExit.GetComponent<RectTransform>().SetAsLastSibling();
        //Debug.Log(eventData.pointerCurrentRaycast.gameObject.name.Substring(0,8));
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            delObject = eventData.pointerCurrentRaycast.gameObject;
            if (delObject.name.Substring(delObject.name.Length-7) == "(Clone)")
            {
                string[] x = delObject.name.Split('(');

                Debug.Log(x[0]);
                if (x[0] == delObject.tag)
                    elementCount--;
                Destroy(delObject);
            }
        }
        else
        {

            if (objSelected == false)
            {
                gName = eventData.pointerCurrentRaycast.gameObject;
                if (gName.name == "BatteryVer" || gName.name == "BatteryGor" || gName.name == "Lamp" || gName.name == "Ampermeter" || gName.name == "Voltmeter")
                    gName.GetComponent<CanvasRenderer>().SetColor(color: Color.green);
                

                if (gName.name == "WireGor" || gName.name == "BatteryVer" || gName.name == "BatteryGor" || gName.name == "Lamp" || gName.name == "Ampermeter" || gName.name == "Voltmeter")
                {
                    objSelected = true;
                }
                tempName = gName.name;
            }
            else
            {
                if (pinSelected == false)
                {
                    GameObject.Find(tempName).GetComponent<CanvasRenderer>().SetColor(color: Color.white);
                    gName = eventData.pointerCurrentRaycast.gameObject;
                    if (    gName.name == "BatteryVer" || gName.name == "BatteryGor" || gName.name == "Lamp" || gName.name == "Ampermeter" || gName.name == "Voltmeter")
                        gName.GetComponent<CanvasRenderer>().SetColor(color: Color.green);
                    if (gName.name.Substring(0, 4) == "Item")
                    {

                        if (tempName == "WireGor")
                        {
                            if (coor1 == Vector2.zero)
                            {
                                coor1 = eventData.pointerCurrentRaycast.gameObject.transform.position;
                                Debug.Log(coor1);
                            }
                            else
                            {
                                coor2 = eventData.pointerCurrentRaycast.gameObject.transform.position;
                                Debug.DrawLine(coor1, coor2, Color.white, 2.5f);
                                Debug.Log(coor2);
                                tempName = null;
                                gName = null;
                                objSelected = false;
                            }
                        }
                        if (gName.tag != "Untagged" && (tempName == "BatteryVer" || tempName == "BatteryGor" || tempName == "Lamp" || tempName == "Ampermeter" || tempName == "Voltmeter"))
                        {
                            coor1 = eventData.pointerCurrentRaycast.gameObject.transform.position;
                            //GameObject.Find(tempName).transform.position = coor1;

                            if (tempName == "BatteryVer")
                            {
                                newPref = Instantiate(GameObject.Find(tempName), coor1, Quaternion.Euler(0f, 0f, -270f));
                            }
                            else
                            {
                                newPref = Instantiate(GameObject.Find(tempName), coor1, transform.rotation);
                            }
                            newPref.transform.parent = canvasParent.transform;
                            newPref.tag = gName.tag;
                            //newPref.transform.localScale = gameObject.transform.localScale;


                            if (gName.tag == tempName)
                            {
                                elementCount++;
                            }
                            Debug.Log(elementCount);



                            tempName = gName.name;
                            coor1 = Vector2.zero;
                            coor2 = Vector2.zero;
                            pinSelected = false;
                        }

                    }
                    else
                    {
                        tempName = gName.name;
                        coor1 = Vector2.zero;
                        coor2 = Vector2.zero;
                        pinSelected = false;

                    }

                }

            }
        }
        


        // Update is called once per frame
            /*void Update()
            {
                if (Input.GetMouseButton(0))
                {
                    Vector2 raycastPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    RaycastHit2D hit = Physics2D.Raycast(raycastPos, Vector2.zero);

                    if (hit.collider != null)
                    {
                        if (objSelected == false && pinSelected == false)
                        {
                            gName = hit.collider.gameObject.name;
                           // string result = gName.Remove(8);
                            Debug.Log("gName");
                            //result = gName.Trim(new char[] {'(', ')'  });
                           // Debug.Log(result);
                            if(gName == "WireGor" || gName == "BatteryVer" || gName == "BatteryGor" || gName == "LampOff" || gName == "Ampermeter" || gName == "Voltmeter")
                            {
                                objSelected = true;   
                            }
                            if(gName.Substring(0, 8)=="ItemSlot")
                            {
                                Debug.Log("Pin shul");
                            }
                        }
                    }
                }

            }*/


    }
}
