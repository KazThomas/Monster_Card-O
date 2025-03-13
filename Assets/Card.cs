using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Card : MonoBehaviour
{
    public int cardAtk, cardShield, cardHealth = 0;

    GameObject canvas;
    GameObject submitButt;
    // Update is called once per frame

    private void Start()
    {
        submitButt = GameObject.FindGameObjectWithTag("text");
    }
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Wheel Room" && this.tag == "Card")
        {
            canvas = GameObject.FindGameObjectWithTag("Canvas");
            transform.SetParent(canvas.transform, false);
            GameObject test = GameObject.FindGameObjectWithTag("test");
            transform.position = test.transform.position;
            //transform.position.x -= 200;

        }

    }

    public void CardValue()
    {
        GameObject[] parts = GameObject.FindGameObjectsWithTag("Part");
        for (int i = 0; i < parts.Length; i++)
        {
            Card_Creation card = GetComponent<Card_Creation>();
            cardAtk += parts[i].GetComponent<Card_Creation>().Atk;
            cardShield += parts[i].GetComponent<Card_Creation>().Shield;
            cardHealth += parts[i].GetComponent<Card_Creation>().Health;
        }
    }
}
