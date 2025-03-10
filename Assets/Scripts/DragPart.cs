using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DragPart : MonoBehaviour
{
    public GameObject part;


    public virtual void CreatePart()
    {
        Debug.Log("Test");

        part.SetActive(true);
        part.transform.position = transform.position;
    }

}
