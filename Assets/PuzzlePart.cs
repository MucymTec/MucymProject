using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePart : MonoBehaviour
{

    public GameObject pivot;
    public Rigidbody body;
    public bool moved = false;

    public void MoveToPivot()
    {
        print("Move" + gameObject.name);
        if (moved)
        {
            moved = true;
            transform.position = pivot.transform.position;
        }
    }

    public void FreezePart()
    {
        print("Freeze" + gameObject.name);
        body.constraints = RigidbodyConstraints.FreezeAll;
        //body.useGravity = false;
    }
}
