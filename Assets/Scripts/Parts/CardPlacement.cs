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
    private Part part;
    private BodyStrength bodyStrength;
    private void Start()
    {
        gameMan = GameObject.FindGameObjectWithTag("GameMan");
        card = GameObject.FindGameObjectWithTag("Card");
        gm = gameMan.GetComponent<GameManager>();
        if (this.gameObject.tag == "Part")
        {
            part =this.gameObject.GetComponent<Part>();
        }
        if (this.gameObject.tag == "Body")
        {
            bodyStrength = this.gameObject.GetComponent<BodyStrength>();
        }
    }
    private void OnMouseUp()
    {
        if (hasDropped == false && canDrop == true)
        {
            Debug.Log("Dropped");
            card.GetComponent<Card>().AddValues();
            card.GetComponent<Card>().UpdateText();
            gm.allParts.Add(this.gameObject);
        }
        hasDropped = true;

    }

    public int AddHealth(int health)
    {
        if (this.gameObject.tag == "Part")
        {
            health += part.Health;
        }
        if (this.gameObject.tag == "Body")
        {
            health += bodyStrength.Health;
        }
        return health;
    }

    public int AddAtk(int atk)
    {
        if (this.gameObject.tag == "Part")
        {
            atk += part.Atk;
        }
        if (this.gameObject.tag == "Body")
        {
            atk += bodyStrength.Atk;
        }
        return atk;
    }

    public int AddShield(int shield)
    {
        if (this.gameObject.tag == "Part")
        {
            shield += part.Shield;
        }
        if (this.gameObject.tag == "Body")
        {
            shield += bodyStrength.Shield;
        }
        return shield;
    }

}
