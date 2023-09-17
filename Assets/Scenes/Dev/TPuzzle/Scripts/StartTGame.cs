using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTGame : MonoBehaviour
{
    public GameObject T;
    public bool started = false;
    public void ActivateT()
    {
        if(!started)
        {
            started = true;
            foreach (Rigidbody rb in T.gameObject.GetComponentsInChildren<Rigidbody>())
            {

                rb.useGravity = true;
            }

        }
    }
}
