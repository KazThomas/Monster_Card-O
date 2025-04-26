using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Card : MonoBehaviour
{
    public int cardAtk, cardShield, cardHealth, cardWeight, cardMaxWeight = 0;

    [SerializeField] private TextMeshProUGUI HealthTxt, AtkTxt, ShieldTxt, WeightTxt, MaxTxt;
    private GameObject gm;

    [SerializeField] GameObject rules;
    [SerializeField] GameObject txtbox;

    GameObject canvas;
    bool addedBody = false;
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
            txtbox.SetActive(false);
            canvas = GameObject.FindGameObjectWithTag("Canvas");
            transform.SetParent(canvas.transform, false);

            GameObject test = GameObject.FindGameObjectWithTag("test");
            transform.position = test.transform.position;

        }
    }

    IEnumerator CardLimit()
    {
        rules.SetActive(true);
        GameObject undoButton = GameObject.Find("Undo");
        yield return new WaitForSeconds(2.8f);
        undoButton.GetComponent<Undo>().UndoButton();
        rules.SetActive(false);
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
                    cardWeight += b.GetComponent<Card_Creation>().Cost;
                }
            }
            GameObject bodies = GameObject.FindGameObjectWithTag("Body");
            if (bodies != null && addedBody == false)
            {
                this.cardAtk += bodies.GetComponent<BodyStrength>().Atk;
                this.cardShield += bodies.GetComponent<BodyStrength>().Shield;
                this.cardHealth += bodies.GetComponent<BodyStrength>().Health;
                this.cardMaxWeight += bodies.GetComponent<BodyStrength>().Strength;
            }
            addedBody = true;
        }
        if (cardWeight > cardMaxWeight)
        {
            StartCoroutine(CardLimit());
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
                    cardWeight -= b.GetComponent<Card_Creation>().Cost;
                }
            }
        }
    }

    public void SubtractBody()
    {
        cardMaxWeight = 0;
        addedBody = false;
    }

    public void UpdateText()
    {
        HealthTxt.SetText(cardHealth.ToString());
        AtkTxt.SetText(cardAtk.ToString());
        ShieldTxt.SetText(cardShield.ToString());
        WeightTxt.SetText(cardWeight.ToString());
        MaxTxt.SetText(cardMaxWeight.ToString());
    }

    public void CardValueEnemy()
    {
        if (this.tag == "Enemy")
        {
            GameObject[] eparts = GameObject.FindGameObjectsWithTag("EParts");
            for (int i = 0; i < eparts.Length; i++)
            {
                cardAtk += eparts[i].GetComponent<Part>().Atk;
                AtkTxt.SetText(cardAtk.ToString());
                cardShield += eparts[i].GetComponent<Part>().Shield;
                ShieldTxt.SetText(cardShield.ToString());
                cardHealth += eparts[i].GetComponent<Part>().Health;
                HealthTxt.SetText(cardHealth.ToString());
            }
            GameObject bodies = GameObject.FindGameObjectWithTag("EBody");
            if (bodies != null)
            {
                cardAtk += bodies.GetComponent<BodyStrength>().Atk;
                AtkTxt.SetText(cardAtk.ToString());
                cardShield += bodies.GetComponent<BodyStrength>().Shield;
                ShieldTxt.SetText(cardShield.ToString());
                cardHealth += bodies.GetComponent<BodyStrength>().Health;
                HealthTxt.SetText(cardHealth.ToString());
            }
        }
    }
}
