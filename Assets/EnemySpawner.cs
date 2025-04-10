using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] Enemies;
    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, Enemies.Length);
        Vector3 bugBoy = new Vector3(5.02f, 0.14f, 0);
        if (rand == 0 )
        {
            Instantiate(Enemies[0], bugBoy, Quaternion.identity);
        }
        else
        {
            Instantiate(Enemies[rand], transform.position, Quaternion.identity);
        }   
    }
}
