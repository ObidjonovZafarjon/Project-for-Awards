using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckAnswerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_InputField time1, time2, time3, road1, road2, road3, ans1, ans2, ans3;
    public TMP_Text BallText;
    public GameObject PanelTop, PanelMain;
    public void CheckAnswers()
    {
        int ansCount=2;
        if(float.Parse(road1.text)/float.Parse(time1.text) == float.Parse(ans1.text))
        {
            ansCount += 1;
            ans1.image.color = Color.green;
        }
        else
        if (float.Parse(road1.text)/float.Parse(time1.text) != float.Parse(ans1.text))
        {
            ans1.image.color = Color.red;
        }

        if (float.Parse(road2.text)/float.Parse(time2.text) == float.Parse(ans2.text))
        {
            ansCount += 1;
            ans2.image.color = Color.green;
        }
        else
        if (float.Parse(road2.text)/float.Parse(time2.text) != float.Parse(ans2.text))
        {
            ans2.image.color = Color.red;
        }

        if (float.Parse(road3.text)/float.Parse(time3.text) == float.Parse(ans3.text))
        {
            ansCount += 1;
            ans3.image.color = Color.green;
        }
        else
        if (float.Parse(road2.text)/float.Parse(time3.text) != float.Parse(ans3.text))
        {
            ans3.image.color = Color.red;
        }

        BallText.text = ansCount.ToString();
    }

    public void BackToLab()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        PanelTop.gameObject.SetActive(false);
        PanelMain.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
