using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DragPart : MonoBehaviour
{
    public GameObject part;

    public bool created = false;

    [SerializeField] private bool limit = false;
    public virtual void CreatePart()
    {
        if (created == false)
        {
            Debug.Log("Test");
            part.SetActive(true);
            part.transform.position = transform.position;
            limit = true;

            if (limit == true)
            {
                GameObject[] bodies = GameObject.FindGameObjectsWithTag("Body");
                foreach (GameObject body in bodies)
                {
                    Destroy(body.GetComponent<DragPart>());
                }
            }
        }
        created = true;

    }
}
