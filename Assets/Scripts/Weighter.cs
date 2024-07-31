using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weighter : MonoBehaviour
{
    public static float sum = 0;
    public static bool[] BooleanObj = { false, false, false, false, false, false, false, false };
    string[] massaText = { "220.5", "264.6", "296.7", "250", "200", "150", "250", "100"};
    
    
    float[] massaNum = { 220.5f, 264.6f, 296.7f, 250f, 200f, 150f, 250f, 100f};
    string[] objects = {"Cone", "Sphere", "Cylinder", "Cube", "Stone", "Crone", "JinLamp", "Capsule"};
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        for (int i = 0; i < 8; i++)
            if (collision.gameObject.name == objects[i])
            {
                BooleanObj[i] = true;
                sum = sum + massaNum[i];
                GameObject.Find("TextWeighter").GetComponent<TMP_Text>().text = sum.ToString() + " gr";
            }
    }

    void Update()
    {
        
    }
}
