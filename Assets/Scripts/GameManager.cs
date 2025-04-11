using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> allParts = new List<GameObject>();
    public List<GameObject> Enemy = new List<GameObject>();

    private WheelSpin wSpin;
    [SerializeField] private GameObject[] prize;
    public GameObject spew;

    private bool hasSpawned = false;
    private void FixedUpdate()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "Wheel Room")
        {
            if (Input.GetMouseButton(0))
            {
                //text = GameObject.FindGameObjectWithTag("text");
                //text.SetActive(false);
                GameObject wheel = GameObject.FindGameObjectWithTag("Wheel");
                wheel.transform.GetChild(0).gameObject.SetActive(true);
                wSpin = FindObjectOfType<WheelSpin>();
                switch (wSpin.boss.name)
                {
                    case "FlyBoy(Clone)":
                        Debug.Log("ITS THE FLY!!!");
                        spew = prize[1];
                        DontDestroyOnLoad(spew);
                        break;
                    case "Radiohead(Clone)":
                        Debug.Log("ITS THE CREEP!!!");
                        spew = prize[0];
                        DontDestroyOnLoad(spew);
                        break;
                    case "Pantalones(Clone)":
                        Debug.Log("ITS THE PANTS");
                        spew = prize[2];
                        DontDestroyOnLoad(spew);
                        break;
                }
            }
            //if (Enemy.Count < 1)
            //{
            //    Enemy.Add(GameObject.FindGameObjectWithTag("Boss"));
            //}
        }
        if (scene.name == "WinScreen" && hasSpawned == false)
        {
            Instantiate(spew);
            //PrizeSpawner ps = GetComponent<PrizeSpawner>();
            //ps.enabled = true;
            hasSpawned = true;
        }
    }
}
