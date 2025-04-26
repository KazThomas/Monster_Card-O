using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Undo : MonoBehaviour
{
    public GameManager gm;
    private GameObject gameMan;
    private GameObject card;
    private void Start()
    {
        gameMan = GameObject.FindGameObjectWithTag("GameMan");
        gm = gameMan.GetComponent<GameManager>();
        card = GameObject.FindWithTag("Card");
    }
    public void UndoButton()
    {
        if (gm.allParts.Count > 0)
        {
            int last = gm.allParts.Count - 1;

            GameObject go = gm.allParts[last];

            CardPlacement place = go.GetComponent<CardPlacement>();
            place.hasDropped = false;
            go.transform.position = Vector3.zero;
            if (go.tag == "Part")
            {
                card.GetComponent<Card>().SubtractValues();
            }
            if (go.tag == "Body")
            {
                card.GetComponent<Card>().SubtractBody();
            }
            card.GetComponent<Card>().UpdateText();
            gm.allParts.RemoveAt(gm.allParts.Count - 1);
        }


        //place.hasDropped = false;
    }
}
