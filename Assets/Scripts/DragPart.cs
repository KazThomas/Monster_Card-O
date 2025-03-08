using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DragPart : MonoBehaviour
{
    [SerializeField] private GameObject part;


    public void CreatePart()
    {
        Debug.Log("Test");

        part.SetActive(true);
        part.transform.position = transform.position;
    }

}
