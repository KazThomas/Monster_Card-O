using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmitButton : MonoBehaviour
{
    GameObject card;
    GameObject test;
    // Start is called before the first frame update
    void Start()
    {
        card = GameObject.FindGameObjectWithTag("Card");
        test = GameObject.FindGameObjectWithTag("test");
    }

    public void Submit()
    {
        card.transform.SetParent(test.transform, false);
        DontDestroyOnLoad(test);
    }

}
