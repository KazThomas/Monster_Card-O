using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPlacement : MonoBehaviour
{
    public bool hasDropped = false;

    public bool canDrop = false;

    public GameManager gm;
    private GameObject gameMan;

    private void Start()
    {
        gameMan = GameObject.FindGameObjectWithTag("GameMan");
        gm = gameMan.GetComponent<GameManager>(); 
    }
    private void OnMouseUp()
    {
        if (hasDropped == false && canDrop == true)
        {
            Debug.Log("Dropped");
            hasDropped = true;
            gm.allParts.Add(this.gameObject);
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
