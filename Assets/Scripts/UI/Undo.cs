using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Undo : MonoBehaviour
{
    public GameManager gm;
    private GameObject gameMan;
    private void Start()
    {
        gameMan = GameObject.FindGameObjectWithTag("GameMan");
        gm = gameMan.GetComponent<GameManager>();
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

            gm.allParts.RemoveAt(gm.allParts.Count - 1);
        }


        //place.hasDropped = false;
    }
}
