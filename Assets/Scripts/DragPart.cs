using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DragPart : MonoBehaviour
{
    private SpriteRenderer sr;
    [SerializeField] private GameObject part;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        
    }

    public void CreatePart()
    {
        Debug.Log("Test");
        part.GetComponent<SpriteRenderer>().sprite = sr.sprite;
        Instantiate(part);
        part.transform.position = Input.mousePosition;
    }    
}
