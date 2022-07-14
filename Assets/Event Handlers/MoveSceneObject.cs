using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveSceneObject : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IUpdateSelectedHandler,ICancelHandler
{
    Vector3 StartPos;
    public void OnCancel(BaseEventData eventData)
    {
          this.transform.position = StartPos;
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        StartPos=this.transform.position;
        EventSystem.current.SetSelectedGameObject(this.gameObject);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void OnUpdateSelected(BaseEventData eventData)
    {
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        plane.Raycast(ray, out float distance);
        this.transform.position = ray.GetPoint(distance) + Vector3.up * 1.5f;
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
