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

    private void Update()
    {
        if (created == true)
        {
            GameObject[] allBodies = GameObject.FindGameObjectsWithTag("BodyIcons");
            foreach (GameObject body in allBodies)
            {
                body.GetComponent<DragPart>().created = true;
            }
        }
    }


    public virtual void CreatePart()
    {
        if (created == false)
        {
            part.SetActive(true);
            part.transform.position = transform.position;
        }
        created = true;

    }
}
