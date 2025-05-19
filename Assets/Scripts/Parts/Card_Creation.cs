using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card_Creation : Part
{
    [SerializeField] private float speed = 40000f;
    [SerializeField] private float scalar = 1.5f;
    [SerializeField] private float rot = 0.01f;
    private Vector3 mousePos;
    private bool spawn = false;

    private CardPlacement place;
    private SpriteRenderer sr;
    private GameManager gm;

    private void Start()
    {
        place = GetComponent<CardPlacement>();
        sr = GetComponent<SpriteRenderer>();
        Health = GetComponent<Part>().Health;
        Atk = GetComponent<Part>().Atk;
        Shield = GetComponent<Part>().Shield;
        gm = GameObject.FindGameObjectWithTag("GameMan").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!spawn)
        {
            transform.position = mousePos;
            spawn = true;
        }
        if (place.hasDropped == false)
        {
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            transform.position = Vector2.Lerp(transform.position, mousePos, speed * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.E) && place.hasDropped == false)
            {
                sr.sortingOrder -= 1;
            }

            if (Input.GetKeyDown(KeyCode.Q) && place.hasDropped == false)
            {
                sr.sortingOrder += 1;
            }

            Transformations();

        }
        if (place.hasDropped == true && !gm.allParts.Contains(this.gameObject))
        {
            if (gameObject.tag == "Part")
            {
                Destroy(gameObject);
                Debug.Log(gameObject.name + " Destroyed");
            }
            if (gameObject.tag == "Body")
            {
                GameObject[] icons = GameObject.FindGameObjectsWithTag("BodyIcons");
                foreach (GameObject icon in icons)
                {
                    icon.GetComponent<DragPart>().created = false;
                }
                transform.position = Vector3.zero;
                Debug.Log(gameObject.name + " Reset");
                gameObject.SetActive(false);
            }
            place.hasDropped = false;
        }
    }

    void Transformations()
    {
        if (Input.GetKey(KeyCode.S))
        {
            transform.localScale -= new Vector3(scalar, scalar, scalar) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.localScale += new Vector3(scalar, scalar, scalar) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.eulerAngles += new Vector3(0, 0, rot) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
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
                
            }
        }
        if (gameObject.tag == "Part" && collision.gameObject.tag == "Bin")
        {
            Destroy(gameObject);
            Debug.Log(gameObject.name + " Destroyed");
        }
        if (gameObject.tag == "Body" && collision.gameObject.tag == "Bin")
        {
            GameObject[] icons = GameObject.FindGameObjectsWithTag("BodyIcons");
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
                
            }
        }
    }
}
