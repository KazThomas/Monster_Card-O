using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DragPart : MonoBehaviour
{
    private Image img;
    private BoxCollider2D box;
    [SerializeField] private GameObject part;

    private void Start()
    {
        img = GetComponent<Image>();
        box = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
      
    }

    public void CreatePart()
    {
        Debug.Log("Test");

        part.SetActive(true);
        part.transform.position = Input.mousePosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
