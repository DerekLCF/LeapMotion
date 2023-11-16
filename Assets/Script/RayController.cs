using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayController : MonoBehaviour
{
    public LineRenderer LineRenderer;
    Ray ray;


    void Update()
    {
        ray = new Ray(transform.position, transform.TransformDirection(Vector3.left) * 10);
        LineRenderer.SetPosition(0, ray.origin);
        LineRenderer.SetPosition(1, ray.origin + ray.direction * 10);
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.red);

    }

    private void OnDrawGizmos()
    {
        RaycastHit hitInfo;
        Gizmos.color = Color.magenta;
        if (Physics.Raycast(ray, out hitInfo))
        {
            Gizmos.DrawSphere(hitInfo.point, 0.1f);

        }


    }

  /*  public GameObject Left_Hand;
    public GameObject Right_Hand;

    public LineRenderer Left_LineRenderer;
    public LineRenderer Right_LineRenderer;
    Ray Left_ray;
    Ray Right_ray;


    void Update()
    {
        Left_ray = new Ray(Left_Hand.transform.position, Left_Hand.transform.TransformDirection(Vector3.forward) * 10);
        Left_LineRenderer.SetPosition(0, Left_ray.origin);
        Left_LineRenderer.SetPosition(1, Left_ray.origin + Left_ray.direction * 10);

        Right_ray = new Ray(Right_Hand.transform.position, Right_Hand.transform.TransformDirection(Vector3.forward) * 10);
        Right_LineRenderer.SetPosition(0, Right_ray.origin);
        Right_LineRenderer.SetPosition(1, Right_ray.origin + Left_ray.direction * 10);

    }*/

}
