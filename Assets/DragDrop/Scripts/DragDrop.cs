using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler {

    [SerializeField] private Canvas canvas;
    public GameObject myPrefab;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private GameObject canvasParent;
    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

        canvasParent = GameObject.Find("GameHandler");
        canvasParent = canvasParent.transform.GetChild(0).gameObject;
        canvasParent = canvasParent.transform.GetChild(0).gameObject;
        canvas = canvasParent.GetComponent<Canvas>();
        Debug.Log(canvasParent.name);

    }

    public void OnBeginDrag(PointerEventData eventData) {
        Debug.Log("OnBeginDrag");
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }
    
    public void OnDrag(PointerEventData eventData) {
        //Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData) {
        Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }
    
    public void OnPointerDown(PointerEventData eventData) {
        if(eventData.position.x<500)
        { 
            float x, y;
            x = eventData.position.x;
            y = eventData.position.y;
            var newPref = Instantiate(myPrefab, new Vector3(x, y, 0), transform.rotation);
            newPref.transform.parent = canvasParent.transform;
            newPref.transform.localScale = gameObject.transform.localScale;
            //        myPrefab.transform.SetParent(canvasParent.transform, false);
        }
        Debug.Log("OnPointerDown");
    }
    

}
