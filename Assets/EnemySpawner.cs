using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] Enemies;
    // Start is called before the first frame update
    void Start()
    {
        Card card = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Card>();
        int rand = Random.Range(0, Enemies.Length);
        Vector3 bugBoy = new Vector3(5.02f, 0.14f, 0); 
        Vector3 pants = new Vector3(5.66f, -1.43f, 0);
        Vector3 tri = new Vector3(5.59f, -1.15f, 0);
        switch (rand)
        {
            case 0:
                Instantiate(Enemies[rand], bugBoy, Quaternion.identity);
                card.CardValueEnemy();
                break;
            case 1:
                Instantiate(Enemies[rand], transform.position, Quaternion.identity);
                card.CardValueEnemy();
                break;
            case 2:
                Instantiate(Enemies[rand], pants, Quaternion.identity);
                card.CardValueEnemy();
                break;
            case 3:
                Instantiate(Enemies[rand], tri, Quaternion.identity);
                card.CardValueEnemy();
                break;
        }
    }
}
