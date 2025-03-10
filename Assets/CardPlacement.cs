using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPlacement : MonoBehaviour
{
    public bool hasDropped = false;


    private void OnMouseUp()
    {
        if (hasDropped == false)
        {
            Debug.Log("Dropped");
            hasDropped = true;
        }
    }

}
