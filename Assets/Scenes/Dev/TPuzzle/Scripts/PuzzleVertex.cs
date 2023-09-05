using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Positions { TopRight,TopLeft,BottomRight,BottomLeft}

[ExecuteInEditMode]
public class PuzzleVertex : MonoBehaviour
{
    public Positions position;
    public PuzzleVertex targetVertex;

    public void AdjustPosition(float width,float height,Vector3 parentPosition)
    {
        transform.position = parentPosition;
        switch (position)
        {
            case Positions.TopRight:
                transform.position = transform.position + new Vector3(width / 2, 0 ,-height/2);
                break;
            case Positions.TopLeft:
                transform.position = transform.position + new Vector3(-width / 2, 0, -height / 2);
                break;
            case Positions.BottomRight:
                transform.position = transform.position + new Vector3(width / 2, 0, height / 2);
                break;
            case Positions.BottomLeft:
                transform.position = transform.position + new Vector3(-width / 2, 0, height / 2);
                break;
            default:
                break;
        }
    }

    public void AdjustSize(float size)
    {
        transform.localScale = new Vector3(size,size,size);
    }

    public void DetectTargetVertex()
    {
        Collider[] hitColliders = Physics.OverlapBox(transform.position, transform.localScale/2);
        foreach (Collider collider in hitColliders)
        {
            if(collider.tag == "PuzzleVertex" && collider.gameObject != gameObject)
            {
                PuzzleVertex vertex = collider.GetComponent<PuzzleVertex>();
                if (vertex != this) 
                {
                    targetVertex = vertex;
                }
            }
        }
    }

    public bool IsCollidingWithTarget()
    {
        Collider[] hitColliders = Physics.OverlapBox(transform.position, transform.localScale / 2);
        foreach (Collider collider in hitColliders)
        {
            if (collider)
            {
                if(collider.tag == "PuzzleVertex" && collider.GetComponent<PuzzleVertex>() == targetVertex)
                {
                    return true;
                }
            }
        }
        return false;
    }

}
