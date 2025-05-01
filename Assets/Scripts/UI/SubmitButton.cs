using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SubmitButton : MonoBehaviour
{
    GameObject card;
    GameObject gm;
    public bool submitted = false;
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
        //card.GetComponent<Card>().CardValue();
        Debug.Log("Atk is: " +card.GetComponent<Card>().cardAtk + " Shield is: " + card.GetComponent<Card>().cardShield + " Health is: " + card.GetComponent<Card>().cardHealth);

        Card_Creation[] finalMonster = GameObject.FindObjectsOfType<Card_Creation>();
        foreach (Card_Creation part in finalMonster)
        {
            part.gameObject.transform.parent = card.transform;
        }

        card.transform.SetParent(null, false);
        DontDestroyOnLoad(card);
        DontDestroyOnLoad(gm);
        SceneManager.LoadScene("Wheel Room");
    }

}
