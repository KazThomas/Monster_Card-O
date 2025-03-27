using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Card : MonoBehaviour
{
    public int cardAtk, cardShield, cardHealth = 0;

    [SerializeField] private TextMeshProUGUI HealthTxt, AtkTxt, ShieldTxt;
    private GameObject gm;

    GameObject canvas;

    // Update is called once per frame

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMan");
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

    public void AddValues()
    {
        if (this.tag == "Card") //its going to add multiples of these per time dropped;
        {
            List<GameObject> parts = gm.GetComponent<GameManager>().allParts;
            GameObject[] bits = GameObject.FindGameObjectsWithTag("Part");
            foreach (GameObject b in bits)
            {
                if (!parts.Contains(b))
                {
                    cardHealth += b.GetComponent<Card_Creation>().Health;
                    cardAtk += b.GetComponent<Card_Creation>().Atk;
                    cardShield += b.GetComponent<Card_Creation>().Shield;
                }
            }
            bool addedBody = false;
            GameObject bodies = GameObject.FindGameObjectWithTag("Body");
            if (bodies != null)
            {
                if (addedBody == false)
                {
                    cardAtk += bodies.GetComponent<BodyStrength>().Atk;
                    cardShield += bodies.GetComponent<BodyStrength>().Shield;
                    cardHealth += bodies.GetComponent<BodyStrength>().Health;
                }
                addedBody = true;
            }
        }
    }

    public void SubtractValues()
    {
        if (this.tag == "Card") //its going to add multiples of these per time dropped;
        {
            List<GameObject> parts = gm.GetComponent<GameManager>().allParts;
            GameObject[] bits = GameObject.FindGameObjectsWithTag("Part");
            foreach (GameObject b in bits)
            {
                if (parts.Contains(b))
                {
                    cardHealth -= b.GetComponent<Card_Creation>().Health;
                    cardAtk -= b.GetComponent<Card_Creation>().Atk;
                    cardShield -= b.GetComponent<Card_Creation>().Shield;
                }
            }
        }
    }

    public void UpdateText()
    {
        HealthTxt.SetText(cardHealth.ToString());
        AtkTxt.SetText(cardAtk.ToString());
        ShieldTxt.SetText(cardShield.ToString());
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
