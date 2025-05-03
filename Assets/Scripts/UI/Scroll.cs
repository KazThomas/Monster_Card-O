using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Scroll : MonoBehaviour
{
    [SerializeField] private GameObject icons;
    private Scrollbar roll;
    private float rollPos;
    [SerializeField] private float mouseWheel = 30f;

    private void Start()
    {
        roll = GetComponent<Scrollbar>();
        rollPos = roll.value;
    }

    private void Update()
    {
        ScrollWheel();

    }

    void ScrollWheel()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            Transform rect = icons.GetComponent<RectTransform>();
            rect.GetComponent<RectTransform>().position += new Vector3(0, mouseWheel * Time.deltaTime , 0);
            rollPos = roll.value;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            Transform rect = icons.GetComponent<RectTransform>();
            rect.GetComponent<RectTransform>().position -= new Vector3(0, mouseWheel * Time.deltaTime, 0);
            rollPos = roll.value;
        }

    }
}
