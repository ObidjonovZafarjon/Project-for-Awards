using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class RegistryScript : MonoBehaviour
{
    public static string UserName, StatusName, ClassName;
    public TMP_Dropdown StatusDropdown, ClassDropdown;
    public TMP_InputField UserNameInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void StartButton()
    {
        StatusName = StatusDropdown.options[StatusDropdown.value].text;
        ClassName = ClassDropdown.options[ClassDropdown.value].text;
        UserName = UserNameInput.text;
        SceneManager.LoadScene("MainScene");
        Debug.Log(StatusName);
        Debug.Log(ClassName);
        Debug.Log(UserName); 
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
