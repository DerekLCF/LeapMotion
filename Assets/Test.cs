using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Test : MonoBehaviour
{

    public void Attached()
    {
        Debug.Log("Attached");
    }
    public void Locked()
    {
        Debug.Log("Locked");

    }
    public void Deteached()
    {
        Debug.Log("Deteached");

    }

    public void WhileAttached()
    {
        Debug.Log("WhileAttached");

    }

    public void WhileLocked()
    {
        Debug.Log("WhileLocked");

    }

    public void OPA()
    {
        Debug.Log("OPA");

    }



}
