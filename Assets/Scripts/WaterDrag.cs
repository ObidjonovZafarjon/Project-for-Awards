using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaterDrag : MonoBehaviour
{
    
    Animator anim;
    public static int chuckedNum;
    public static bool chucked = false;
    float heightWater;
    Transform cyl;
    string[] hArr = { "35,7", "31,2", "34,6", "36" };
    public static string[] fourE = { "Stone", "Crone", "JinLamp", "Capsule" };
    public static bool[] chuckedArray = { false, false, false, false };
    float[] hWater = { 0.67f, 0.48f, 0.60f, 0.72f };
    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void OnTriggerEnter(Collider forWater)
    {

        Debug.Log(forWater.gameObject.tag);
        for (int i = 0; i < 4; i++)
        {
            if(forWater.name==fourE[i])
            {
                chuckedArray[i] = true;
                chuckedNum = i;
            }
        }
       // forWater.gameObject.tag = "chucked";
       // chucked = true;
        forWater.GetComponent<Rigidbody>().drag = 10;
        
        
        
        cyl = GameObject.Find("Menzurka").gameObject.transform.Find("Cylinder");
        cyl.gameObject.tag = forWater.gameObject.name;
        
        for (int i=0; i<4; i++)
        {
            if(forWater.gameObject.name == fourE[i])
            {
                //waterAnim.clip = waterClips[i];
                //waterAnim.Play();
                anim.SetTrigger(fourE[i] + "Anim");
                
                GameObject.Find("NumberWater").gameObject.transform.Find("Masofa").GetComponent<TMP_Text>().text = hArr[i];
                
                //cyl.transform.localScale = new Vector3(1, hWater[i], 1);
                StartCoroutine(SlowScale(hWater[i]));
            }
        }
    }
    void OnTriggerStay(Collider forWater)
    {
        Debug.Log("Stayed");
    }

    IEnumerator SlowScale(float num)
    {
        if (chucked == false)
        {
            chucked = true;
            for (float q = 0.31f; q < num; q += .02f)
            {
                transform.localScale = new Vector3(1, q, 1);
                yield return new WaitForSeconds(.001f);
            }
        }
        
    }
    public IEnumerator MinScale()
    {
        if (chucked)
        {
            chucked = false;
            chuckedArray[chuckedNum] = false;
            float statWat = GameObject.Find("Menzurka").gameObject.transform.Find("Cylinder").transform.localScale.y;
            Debug.Log(GameObject.Find("Menzurka").gameObject.transform.Find("Cylinder").transform.localScale.y);
            for (float q = statWat; q > 0.31f; q -= .02f)
            {
                transform.localScale = new Vector3(1, q, 1);
                yield return new WaitForSeconds(.001f);
            }
        }
    }





}
