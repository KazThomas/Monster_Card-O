using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Card : MonoBehaviour
{
    GameObject canvas;
    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Wheel Room")
        {
            canvas = GameObject.FindGameObjectWithTag("Canvas");
            transform.SetParent(canvas.transform, false);
            GameObject test = GameObject.FindGameObjectWithTag("test");
            transform.position = test.transform.position;
            //transform.position.x -= 200;

        }
    }
}
