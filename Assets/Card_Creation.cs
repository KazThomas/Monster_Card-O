using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card_Creation : MonoBehaviour
{
    [SerializeField] private float speed = 0.06f;
    private Vector3 mousePos;
    private bool spawn = false;

    private CardPlacement place;

    private void Start()
    {
        place = GetComponent<CardPlacement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!spawn)
        {
            transform.position = mousePos;
            spawn = true;
        }
        if (Input.GetMouseButton(0) && place.hasDropped == false)
        {
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            transform.position = Vector2.Lerp(transform.position, mousePos, speed);
        }

        if (Input.GetKey(KeyCode.S) && place.hasDropped == false)
        {
            GetComponent<SpriteRenderer>().sortingOrder -= 1;
        }

        if (Input.GetKey(KeyCode.W) && place.hasDropped == false)
        {
            GetComponent<SpriteRenderer>().sortingOrder += 1;
        }
    }
}
