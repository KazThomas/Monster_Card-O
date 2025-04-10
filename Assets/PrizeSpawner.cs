using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrizeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] winnings;

    private GameManager gm;

    [SerializeField] private GameObject spawnLoc;

    private void Start()
    {
        spawnLoc = GameObject.FindGameObjectWithTag("Spawner");
        gm = GameObject.FindGameObjectWithTag("GameMan").GetComponent<GameManager>();

        Instantiate(gm.spew, spawnLoc.transform);
    }
}
