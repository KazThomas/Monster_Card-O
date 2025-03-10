using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DragPart : MonoBehaviour
{
    public GameObject part;

    private bool limit = false;
    public virtual void CreatePart()
    {
        Debug.Log("Test");
        if (limit == false )
        {
            limit = true;
            part.SetActive(true);
            part.transform.position = transform.position;

        }
       
    }

}
