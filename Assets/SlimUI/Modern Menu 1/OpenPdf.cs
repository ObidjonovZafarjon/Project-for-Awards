using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OpenPdf : MonoBehaviour
{
   
    
    // Update is called once per frame
    void Update()
    {

    }

    void OpeningPdf()
    {
        string filePath = System.IO.Path.Combine(Application.streamingAssetsPath, "71.pdf");
        System.Diagnostics.Process.Start(filePath);
    }
    
    
}
