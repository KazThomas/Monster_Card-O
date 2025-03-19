using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Card : MonoBehaviour
{
    public int cardAtk, cardShield, cardHealth = 0;

    GameObject canvas;
    // Update is called once per frame

    private void Start()
    {
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
        if (this.tag == "Card")
        {
            GameObject[] parts = GameObject.FindGameObjectsWithTag("Part");
            for (int i = 0; i < parts.Length; i++)
            {
                cardAtk += parts[i].GetComponent<Card_Creation>().Atk;
                cardShield += parts[i].GetComponent<Card_Creation>().Shield;
                cardHealth += parts[i].GetComponent<Card_Creation>().Health;
            }
            GameObject bodies = GameObject.FindGameObjectWithTag("Body");
            if (bodies != null)
            {
                cardAtk += bodies.GetComponent<BodyStrength>().Atk;
                cardShield += bodies.GetComponent<BodyStrength>().Shield;
                cardHealth += bodies.GetComponent<BodyStrength>().Health;
            }
        }

    }

    public void CardValueEnemy()
    {

        if (this.tag == "Enemy")
        {
            GameObject[] eparts = GameObject.FindGameObjectsWithTag("EParts");
            for (int i = 0; i < eparts.Length; i++)
            {
                cardAtk += eparts[i].GetComponent<Part>().Atk;
                cardShield += eparts[i].GetComponent<Part>().Shield;
                cardHealth += eparts[i].GetComponent<Part>().Health;
            }
            GameObject bodies = GameObject.FindGameObjectWithTag("EBody");
            if (bodies != null)
            {
                cardAtk += bodies.GetComponent<BodyStrength>().Atk;
                cardShield += bodies.GetComponent<BodyStrength>().Shield;
                cardHealth += bodies.GetComponent<BodyStrength>().Health;
            }
        }
    }
}
