using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneSwitcher : MonoBehaviour
{
    private string ActiveSceneName;

    void Start()
    {
        ActiveSceneName = SceneManager.GetActiveScene().name;
    }
    public void desktopSwitch()
    {
        if (ActiveSceneName == "ReadFile" || ActiveSceneName == "QuizScene")
            SceneManager.LoadScene("Document");
        else
        if (ActiveSceneName == "ReadFile2" || ActiveSceneName == "QuizScene2")
            SceneManager.LoadScene("Document2");
        else
        if (ActiveSceneName == "ReadFile3" || ActiveSceneName == "QuizScene3")
            SceneManager.LoadScene("Document3");
        else
        if (ActiveSceneName == "ReadFile4" || ActiveSceneName == "QuizScene4")
            SceneManager.LoadScene("Document4");
    }
    public void QuizScene()
    {
        if (ActiveSceneName == "ReadFile")
            SceneManager.LoadScene("QuizScene");
        else
        if (ActiveSceneName == "ReadFile2")
            SceneManager.LoadScene("QuizScene2");
        else
        if (ActiveSceneName == "ReadFile3")
            SceneManager.LoadScene("QuizScene3");
        else
        if (ActiveSceneName == "ReadFile4")
            SceneManager.LoadScene("QuizScene4");

    }
    void FixedUpdate()
    {
        
    //    GameObject.Find("Text").GetComponent<Text>().text=i.ToString(); 
    }
    
}
