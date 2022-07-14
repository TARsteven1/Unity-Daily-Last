using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIPopupOnHover : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public static event System.Action<GameObject, PointerEventData> onPointEnter;
    public static event System.Action<GameObject, PointerEventData> onPointExit;
    public void OnPointerEnter(PointerEventData eventData)
    {
        onPointEnter?.Invoke(this.gameObject, eventData);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        onPointExit?.Invoke(this.gameObject, eventData);
        
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
