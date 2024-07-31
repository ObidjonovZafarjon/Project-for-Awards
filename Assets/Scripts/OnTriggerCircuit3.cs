using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class OnTriggerCircuit3 : MonoBehaviour
{
    string ActiveScene;

    private void Start()
    {
        ActiveScene = SceneManager.GetActiveScene().name;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Entered");

        if (ForCircuit.sendScene33 == 0 && ActiveScene=="LabThird")
        {
            PlayerPrefs.SetFloat("ply_x", GameObject.Find("FP1").transform.position.x);
            PlayerPrefs.SetFloat("ply_y", GameObject.Find("FP1").transform.position.y);
            PlayerPrefs.SetFloat("ply_z", GameObject.Find("FP1").transform.position.z);
            PlayerPrefs.Save();
            SceneManager.LoadScene("CircuitScene" + this.name);
        }
        else
        if (ForCircuit2.sendScene43 == 0 && ActiveScene == "LabFour")
        {
            PlayerPrefs.SetFloat("ply_x", GameObject.Find("FP1").transform.position.x);
            PlayerPrefs.SetFloat("ply_y", GameObject.Find("FP1").transform.position.y);
            PlayerPrefs.SetFloat("ply_z", GameObject.Find("FP1").transform.position.z);
            PlayerPrefs.Save();
            SceneManager.LoadScene("CircuitScene" + this.name);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Exit");
    }
}
