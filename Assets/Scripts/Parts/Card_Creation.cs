using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card_Creation : Part
{
    [SerializeField] private float speed = 0.06f;
    [SerializeField] private float scalar = 0.4f;
    [SerializeField] private float rot = 0.01f;
    private Vector3 mousePos;
    private bool spawn = false;

    private CardPlacement place;
    private SpriteRenderer sr;


    private void Start()
    {
        place = GetComponent<CardPlacement>();
        sr = GetComponent<SpriteRenderer>();
        Health = GetComponent<Part>().Health;
        Atk = GetComponent<Part>().Atk;
        Shield = GetComponent<Part>().Shield;
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

            if (Input.GetKeyDown(KeyCode.S) && place.hasDropped == false)
            {
                sr.sortingOrder -= 1;
            }

            if (Input.GetKeyDown(KeyCode.W) && place.hasDropped == false)
            {
                sr.sortingOrder += 1;
            }

            Transformations();

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6) //card layer
        {
            if (collision.gameObject.activeInHierarchy)
            {
                Debug.Log("CAN PLACE");
                place.canDrop = true;
                transform.parent = collision.transform;
            }
        }
        if (gameObject.tag == "Part" && collision.gameObject.tag == "Bin")
        {
            Destroy(gameObject);
            Debug.Log(gameObject.name + " Destoryed");
        }
        if (gameObject.tag == "Body" && collision.gameObject.tag == "Bin")
        {
            GameObject[] icons = GameObject.FindGameObjectsWithTag("Icons");
            foreach (GameObject icon in icons)
            {
                icon.GetComponent<DragPart>().created = false;
            }
            transform.position = Vector3.zero;
            Debug.Log(gameObject.name + " Reset");
            gameObject.SetActive(false);
            

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Card")
        {
            if (collision.gameObject.activeInHierarchy)
            {
                Debug.Log("NO PLACE");
                place.canDrop = false;
                transform.SetParent(null, true);
            }
        }
    }
}
