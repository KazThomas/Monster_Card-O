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
    private void Start()
    {
        gameMan = GameObject.FindGameObjectWithTag("GameMan");
        card = GameObject.FindGameObjectWithTag("Card");
        gm = gameMan.GetComponent<GameManager>();
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
