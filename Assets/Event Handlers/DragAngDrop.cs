using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;

public class DragAngDrop : MonoBehaviour, IPointerDownHandler, IPointerUpHandler,IUpdateSelectedHandler
{
    [SerializeField]
    GameObject prefab;
    GameObject objectBeginDragged;

    public void OnPointerDown(PointerEventData eventData)
    {
        objectBeginDragged =Instantiate(prefab);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        objectBeginDragged=null;
    }

    public void OnUpdateSelected(BaseEventData eventData)
    {
        if (objectBeginDragged!=null)
        {
            Plane plane = new Plane(Vector3.up, Vector3.zero);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            plane.Raycast(ray,out float distance);
            objectBeginDragged.transform.position = ray.GetPoint(distance)+Vector3.up*1.5f;

        }
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
