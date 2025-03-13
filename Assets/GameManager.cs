using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> allParts = new List<GameObject>();

    public GameObject text;

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
            }
        }
    }
}
