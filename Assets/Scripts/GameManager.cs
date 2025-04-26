using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> allParts = new List<GameObject>();
    public List<GameObject> Enemy = new List<GameObject>();

    public List<GameObject> Awards = new List<GameObject>();

    private WheelSpin wSpin;
    [SerializeField] private GameObject[] prize;
    public GameObject spew;

    private bool hasSpawned = false;
    public bool showing = false;
    private void FixedUpdate()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "SampleScene" && spew != null)
        {
            hasSpawned = false;
            GameObject[] icons = GameObject.FindGameObjectsWithTag("Icons");
            foreach (GameObject icon in icons)
            {
                foreach (GameObject award in Awards)
                {
                    switch (award.name)
                    {
                        case "grabbs":
                            if (icon.name == "Grabs")
                            {
                                icon.GetComponent<NonBodyParts>().unlocked = true;
                            }
                            break;
                        case "Jets":
                            if (icon.name == "Jets")
                            {
                                icon.GetComponent<NonBodyParts>().unlocked = true;
                            }
                            break;
                        case "jeans":
                            if (icon.name == "Jeans")
                            {
                                icon.GetComponent<NonBodyParts>().unlocked = true;

                            }
                            break;
                        case "Orbs":
                            if (icon.name == "Orbs")
                            {
                                icon.GetComponent<NonBodyParts>().unlocked = true;
                            }
                            break;

                    }
                }
            }
        }


        if (scene.name == "Wheel Room")
        {
            
            if (Input.GetMouseButton(0))
            {
                //text = GameObject.FindGameObjectWithTag("text");
                //text.SetActive(false);
                GameObject controls = GameObject.FindGameObjectWithTag("Controls");
                controls.transform.GetChild(0).gameObject.SetActive(false);
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
                    case "Dodge(Clone)":
                        Debug.Log("ITS THE TRI-BEAM");
                        spew = prize[3];
                        DontDestroyOnLoad(spew);
                        break;
                }
                showing = true;
            }
            //if (Enemy.Count < 1)
            //{
            //    Enemy.Add(GameObject.FindGameObjectWithTag("Boss"));
            //}
        }
        if (scene.name == "WinScreen" && hasSpawned == false )
        {
            Instantiate(spew);
            //PrizeSpawner ps = GetComponent<PrizeSpawner>();
            //ps.enabled = true;
            hasSpawned = true;
            Awards.Add(spew);
            Invoke("BackToSetUp", 3.2f);
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            OnApplicationQuit();
        }
    }

    private void OnApplicationQuit()
    {
        Application.Quit();
    }
}
