using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class PlayerMove : MonoBehaviour
{
    Seeker seeker;
    List<Vector3> targetPoints;
    float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        seeker = transform.GetComponent<Seeker>();
        seeker.pathCallback += OnPathComplete;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray,out raycastHit))
            {
                seeker.StartPath(transform.position, raycastHit.point);
            }
        }
    }
    void OnPathComplete(Path path)
    {
        targetPoints =new List<Vector3>( path.vectorPath);
    }
    private void FixedUpdate()
    {
        if (targetPoints!=null&& targetPoints.Count!=0)
        {
            Vector3 dir = (targetPoints[0] - transform.position).normalized;
            //transform.LookAt(transform.position + dir);
            Quaternion quaternion= Quaternion.LookRotation(targetPoints[0] ,transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation , quaternion,0.1f);
            transform.position += dir * Time.fixedDeltaTime * speed;
            if (Vector3.Distance(targetPoints[0], transform.position) <=0.1)
            {
                targetPoints.RemoveAt(0);
            }
        }
    }
}
