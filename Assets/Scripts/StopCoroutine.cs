using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StopCoroutine : MonoBehaviour
{
    private GameObject wallT;
   
    // Start is called before the first frame update
    void OnCollisionEnter(Collision other)
    {
        
            Debug.Log("OK");
            //StopAllCoroutines();  
        GameObject.Find("ForCheckCollision").GetComponent<Text>().text = "1";

        wallT = GameObject.Find("wallLab");
        Debug.Log(wallT.transform.position.x);
        //wallT.transform.position = new Vector3(1551.35f, 11.22821f, -11.98269f);
        wallT.transform.position = new Vector3(1551.35f, 11.22821f, -11.98269f);
        wallT.transform.localScale = new Vector3(0.03376491f, 0.7427899f, 4.218006f);
    }
}
