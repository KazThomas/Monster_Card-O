using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPlacement : MonoBehaviour
{
    public bool hasDropped = false;

    public bool canDrop = false; 
    private void OnMouseUp()
    {
        if (hasDropped == false && canDrop == true)
        {
            Debug.Log("Dropped");
            hasDropped = true;
        }

    }

    private void Update()
    {
        //RaycastHit2D hit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));

        //Debug.Log(hit.transform.name);

        //if (Input.GetMouseButtonUp(0))
        //{
        //    RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
        //    Debug.Log(rayHit.transform.name);
        //}
    }

}
