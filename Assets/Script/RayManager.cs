using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayManager : MonoBehaviour
{
    public static RayManager Instance;
    public bool RayOn;


    public Transform Left_Transform;
    public LineRenderer Left_LineRenderer;
    Ray Left_ray;
    RaycastHit Left_RCH;
    public GameObject Left_HitBall;

    public Transform Right_Transform;
    public LineRenderer Right_LineRenderer;
    Ray Right_ray;
    RaycastHit Right_RCH;
    public GameObject Right_HitBall;


    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }
    private void Start()
    {
        CheckOnOff();
    }

    void CheckOnOff() {
        Debug.Log("Check ON OFF" + PlayerPrefs.GetInt("Name"));
        if (PlayerPrefs.GetInt("Name") == 1)
        {
            RayOn = true;
        }
        else
        {
            RayOn = false;
        }
    }
    void Update()
    {
        if (RayOn != true) {

            Left_HitBall.SetActive(false);
            Left_LineRenderer.gameObject.SetActive(false);
            return;
        }

        Debug.Log("On");
        if (Left_Transform.gameObject.activeSelf )
        {
            Left_HitBall.SetActive(true);
            Left_LineRenderer.gameObject.SetActive(true);
        }
        else {
            Left_HitBall.SetActive(false);
            Left_LineRenderer.gameObject.SetActive(false);
        }

        if (Right_Transform.gameObject.activeSelf)
        {
            Right_HitBall.SetActive(true);
            Right_LineRenderer.gameObject.SetActive(true);
        }
        else
        {
            Right_HitBall.SetActive(false);
            Right_LineRenderer.gameObject.SetActive(false);
        }


        Left_ray = new Ray(Left_Transform.position, Left_Transform.TransformDirection(Vector3.left) );
        if (Physics.Raycast(Left_ray, out Left_RCH, 5f))
        {
            Debug.DrawRay(Left_Transform.position, Left_Transform.TransformDirection(Vector3.left) * Left_RCH.distance, Color.green);
            Left_HitBall.SetActive(true);
            Left_HitBall.transform.position = Left_RCH.point;
        }
        else {
            Debug.DrawRay(Left_Transform.position, Left_Transform.TransformDirection(Vector3.left) * 10, Color.red);
            Left_HitBall.SetActive(false);
        }

        Left_LineRenderer.SetPosition(0, Left_ray.origin);
        Left_LineRenderer.SetPosition(1, Left_ray.origin+ Left_ray.direction * Left_RCH.distance);

        Right_ray = new Ray(Right_Transform.position, Right_Transform.TransformDirection(Vector3.left));
        if (Physics.Raycast(Right_ray, out Right_RCH, 5f))
        {
            Debug.DrawRay(Right_Transform.position, Right_Transform.TransformDirection(Vector3.left) * Right_RCH.distance, Color.green);
            Right_HitBall.SetActive(true);
            Right_HitBall.transform.position = Right_RCH.point;
        }
        else
        {
            Debug.DrawRay(Right_Transform.position, Right_Transform.TransformDirection(Vector3.left) * 10, Color.red);
            Right_HitBall.SetActive(false);
        }

        Right_LineRenderer.SetPosition(0, Right_ray.origin);
        Right_LineRenderer.SetPosition(1, Right_ray.origin + Right_ray.direction * Right_RCH.distance);

    }

    private void OnDrawGizmos()
    {
        RaycastHit hitInfo;
        Gizmos.color = Color.magenta;
        if (Physics.Raycast(Left_ray, out hitInfo))
        {
            Gizmos.DrawSphere(hitInfo.point, 0.01f);

        }
        if (Physics.Raycast(Right_ray, out hitInfo))
        {
            Gizmos.DrawSphere(hitInfo.point, 0.01f);

        }

    }



}
