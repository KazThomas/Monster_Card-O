using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] Enemies;
    [SerializeField] private GameObject loc; 
    [SerializeField] private GameObject Bigloc;
    [SerializeField] private TextMeshProUGUI Monname;
    // Start is called before the first frame update
    void Start()
    {
        Card card = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Card>();

        int rand = Random.Range(0, Enemies.Length);
        Vector3 creep = new Vector3(5.72f, -1.31f, 0);
        Vector3 bugBoy = new Vector3(this.transform.position.x,this.transform.position.y, 0); 
        Vector3 pants = new Vector3(6.05f, -1.43f, 0);
        Vector3 tri = new Vector3(5.91f, -1.15f, 0);

        if (Screen.width == 5120)
        {
            Vector3 bigPos = Bigloc.transform.position;
            switch (rand)
            {
                case 0:
                    Instantiate(Enemies[rand], new Vector3(bigPos.x - 0.5f, bigPos.y + 1f, 1), Quaternion.identity);
                    Monname.text = Enemies[rand].name;
                    card.CardValueEnemy();
                    break;
                case 1:
                    Instantiate(Enemies[rand], new Vector3(bigPos.x, bigPos.y, 1), Quaternion.identity);
                    Monname.text = Enemies[rand].name;
                    card.CardValueEnemy();
                    break;
                case 2:
                    Instantiate(Enemies[rand], new Vector3(bigPos.x, bigPos.y, 1), Quaternion.identity);
                    Monname.text = Enemies[rand].name;
                    card.CardValueEnemy();
                    break;
                case 3:
                    Instantiate(Enemies[rand], new Vector3(bigPos.x, bigPos.y, 1), Quaternion.identity);
                    Monname.text = Enemies[rand].name;
                    card.CardValueEnemy();
                    break;
            }
        }
        else
        {
            Vector3 pos = loc.transform.position;
            switch (rand)
            {
                case 0:
                    Instantiate(Enemies[rand], new Vector3(pos.x - 0.5f, pos.y + 1f, 1), Quaternion.identity); ;
                    Monname.text = Enemies[rand].name;
                    card.CardValueEnemy();
                    break;
                case 1:
                    Instantiate(Enemies[rand], new Vector3(pos.x - 0.06f, pos.y - 0.15f, 1), Quaternion.identity);
                    Monname.text = Enemies[rand].name;
                    card.CardValueEnemy();
                    break;
                case 2:
                    Instantiate(Enemies[rand], new Vector3(pos.x + 0.06f, pos.y, 1), Quaternion.identity);
                    Monname.text = Enemies[rand].name;
                    card.CardValueEnemy();
                    break;
                case 3:
                    Instantiate(Enemies[rand], new Vector3(pos.x, pos.y, 1), Quaternion.identity);
                    Monname.text = Enemies[rand].name;
                    card.CardValueEnemy();
                    break;
            }
        }
       
    }
}
