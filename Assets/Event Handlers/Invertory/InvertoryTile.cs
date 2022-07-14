using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InvertoryTile : MonoBehaviour,IBeginDragHandler,IEndDragHandler,IDragHandler
{
    Vector2 offset;
    Transform StartPos;
    public void OnBeginDrag(PointerEventData eventData)
    {
        StartPos=this.transform.parent;
        this.transform.SetParent(this.transform.root);
        this.transform.SetAsLastSibling();

        offset = eventData.position - new Vector2(this.transform.position.x, this.transform.position.y);
        this.GetComponent<Image>().raycastTarget = false;

    }

    public void OnDrag(PointerEventData eventData)
    {
       this.transform.position=eventData.position-offset;
        this.GetComponent<Outline>().enabled=true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.GetComponent<Image>().raycastTarget = true;
        //FindObjectOfType<>()
            if (this.transform.parent.GetComponent<Slot>()==null)
        {
            this.transform.SetParent(StartPos);
        }
         this.GetComponent<Outline>().enabled = false;
    }

   
}
