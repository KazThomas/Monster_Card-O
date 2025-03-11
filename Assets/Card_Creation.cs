using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card_Creation : MonoBehaviour
{
    [SerializeField] private float speed = 0.06f;
    [SerializeField] private float scalar = 0.4f;
    [SerializeField] private float rot = 0.01f;
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

            Transformations();
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

    void Transformations()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            transform.localScale -= new Vector3(scalar, scalar, scalar);
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            transform.localScale += new Vector3(scalar, scalar, scalar);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.eulerAngles += new Vector3(0, 0, rot) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.eulerAngles -= new Vector3(0, 0, rot) * Time.deltaTime;
        }
    }
}
