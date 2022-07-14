using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIPopupMenu : MonoBehaviour
{
    CanvasGroup canvasGroup;
    [SerializeField]
    Text text1;    
    [SerializeField]
    Text text2;
    private void OnEnable()
    {
        UIPopupOnHover.onPointEnter += DisplayeInfo;
        UIPopupOnHover.onPointExit += CloseWindow;
        canvasGroup = this.GetComponent<CanvasGroup>();
    }

    private void DisplayeInfo(GameObject arg1, PointerEventData   pedata)
    {
        this.transform.position = pedata.position + new Vector2(300, 0);
        canvasGroup.alpha = 1;
        text1.text = arg1.name;
        text1.text += $"\n Pos:{arg1.transform.position }";
        text1.text += $"\n Rot:{arg1.transform.rotation }";
    }

    private void CloseWindow(GameObject arg1, PointerEventData arg2)
    {
        
        canvasGroup.alpha = 0;
    }

    private void OnDisable()
    {
        UIPopupOnHover.onPointEnter -= DisplayeInfo;
        UIPopupOnHover.onPointExit -= CloseWindow;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
