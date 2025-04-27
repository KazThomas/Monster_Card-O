using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPlacement : MonoBehaviour
{
    public bool hasDropped = false;

    public bool canDrop = false;

    public GameManager gm;
    private GameObject gameMan;
    private GameObject card;
    private Part part;
    private BodyStrength bodyStrength;
    private void Start()
    {
        gameMan = GameObject.FindGameObjectWithTag("GameMan");
        card = GameObject.FindGameObjectWithTag("Card");
        gm = gameMan.GetComponent<GameManager>();
        if (this.gameObject.tag == "Part")
        {
            part =this.gameObject.GetComponent<Part>();
        }
        if (this.gameObject.tag == "Body")
        {
            bodyStrength = this.gameObject.GetComponent<BodyStrength>();
        }
    }
    private void OnMouseUp()
    {
        if (canDrop == true)
        {
            if (hasDropped == false)
            {
                Debug.Log("Dropped");
                card.GetComponent<Card>().AddValues();
                card.GetComponent<Card>().UpdateText();
                gm.allParts.Add(this.gameObject);
            }
        }
        
        hasDropped = true;

    }
}
