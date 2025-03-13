using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SubmitButton : MonoBehaviour
{
    GameObject card;
    GameObject gm;
    //GameObject test;
    // Start is called before the first frame update
    void Start()
    {
        card = GameObject.FindGameObjectWithTag("Card");
        gm = GameObject.FindGameObjectWithTag("GameMan");
        //test = GameObject.FindGameObjectWithTag("test");
    }

    public void Submit()
    {
        card.transform.SetParent(null, false);
        DontDestroyOnLoad(card);
        DontDestroyOnLoad(gm);
        SceneManager.LoadScene("Wheel Room");
    }

}
