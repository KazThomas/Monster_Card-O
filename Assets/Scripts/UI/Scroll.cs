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
    [SerializeField] private float yPos = 3f;
    [SerializeField] private float mouseWheel = 30f;
    private GameManager gameManager;
    private void Start()
    {
        roll = GetComponent<Scrollbar>();
        rollPos = roll.value;
        gameManager = GameObject.FindGameObjectWithTag("GameMan").GetComponent<GameManager>();
    }

    private void Update()
    {
        ScrollWheel();

    }

    void ScrollWheel()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && !Input.GetMouseButton(0))
        {
            Transform rect = icons.GetComponent<RectTransform>();
            rect.GetComponent<RectTransform>().localPosition += new Vector3(0, mouseWheel, 0);
            rollPos = roll.value;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0 && !Input.GetMouseButton(0))
        {
            Transform rect = icons.GetComponent<RectTransform>();
            rect.GetComponent<RectTransform>().localPosition -= new Vector3(0, mouseWheel, 0);
            rollPos = roll.value;
        }

    }

    public void OnMouseDrag()
    {
        Debug.Log("test");

        if (roll.value > rollPos)
        {
           Transform rect = icons.GetComponent<RectTransform>();
            rect.GetComponent<RectTransform>().localPosition += new Vector3(0, yPos, 0);
            rollPos = roll.value;
        }

        if (roll.value < rollPos)
        {
            Transform rect = icons.GetComponent<RectTransform>();
            rect.GetComponent<RectTransform>().localPosition -= new Vector3(0, yPos, 0);
            rollPos = roll.value;
        }

    }
}
