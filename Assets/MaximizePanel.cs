using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class MaximizePanel : MonoBehaviour, IPointerClickHandler
{
    private bool isMaximized = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Maximize()
    {

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        
        if(isMaximized == false)
        {
            this.transform.localScale = new Vector2(4, 4);
            this.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            isMaximized = true;
        }
        else
        {
            this.transform.localScale = new Vector2(1, 1);
            this.GetComponent<RectTransform>().anchoredPosition = new Vector2(515, 170);
            isMaximized = false;
        }



        

        
    }

        // Update is called once per frame
        void Update()
    {
        
    }
}
