using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selectable : MonoBehaviour
{
    public GameObject handIcon;
    private Color myMat;
    public void Select()
    {
        myMat = GetComponent<Renderer>().material.color;
       // Debug.Log(myMat);
        GetComponent<Renderer>().material.color = Color.yellow;
        handIcon.GetComponent<Image>().gameObject.SetActive(true);
    }
    public void DiSelect()
    {
        //Debug.Log(myMat);
        //GetComponent<Renderer>().material.color = myMat;
        GetComponent<Renderer>().material.color = Color.white;
        handIcon.GetComponent<Image>().gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
