using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WheelSpin : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float maxSpeed = 120f;
    [SerializeField] private GameObject hand;
    [SerializeField] private GameObject tieGo;
    private Vector3 rotZ;
    private bool stop = false;
    [SerializeField] private bool startWatch = false;
    private float stopWatch = 0.0f;

    private GameManager gm;
    GameObject playerCard;
    GameObject enemyCard;
    public GameObject boss;

    private void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("GameMan").GetComponent<GameManager>();
        playerCard = GameObject.FindGameObjectWithTag("Card");
        enemyCard = GameObject.FindGameObjectWithTag("Enemy");
        boss = GameObject.FindGameObjectWithTag("Boss");
    }

    private void FixedUpdate()
    {
        rotZ  = new Vector3(0,0, speed * Time.deltaTime);

        if ( speed  < maxSpeed && !stop)
        {
            speed += Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            speed = 0;
            rotZ = Vector3.zero;
            stop = true;

            Debug.Log("stopped");

            ZoneCheck();

        }

        if (Input.GetKey(KeyCode.Space))
        {
            startWatch = true;
        }

        if (!stop) 
        {
            hand.transform.eulerAngles -= rotZ;
        }
        if (startWatch)
        {
            stopWatch += Time.deltaTime;
            if (stopWatch <= 3.0f)
            {
                float sUp = Random.Range(5f, 9f);
                speed += sUp;
            }
            if (stopWatch > 3f)
            {
                float rand = Random.Range(2f, 5f);
                speed -= rand;
                if (speed <= 0)
                {
                    speed = 0;
                }

                if (speed == 0)
                {
                    ZoneCheck();
                }
            }
        }
    }

    void ZoneCheck()
    {
        if (hand.transform.eulerAngles.z <= 360f && transform.eulerAngles.z > 241f)
        {
            Atk();
        }

        if (hand.transform.eulerAngles.z <= 241f && hand.transform.eulerAngles.z > 119f)
        {
            Shield();
        }

        if (hand.transform.eulerAngles.z <= 119f && hand.transform.eulerAngles.z > 0f)
        {
            Health();
        }
    }

    void Atk()
    {
        Debug.Log("Atk stat");
        if (playerCard.GetComponent<Card>().cardAtk > enemyCard.GetComponent<Card>().cardAtk)
        {
            Invoke("WinScreen", 2f);
        }
        if (enemyCard.GetComponent<Card>().cardAtk > playerCard.GetComponent<Card>().cardAtk)
        {
            Invoke("LoseScreen", 2f);
        }
        if (playerCard.GetComponent<Card>().cardAtk == enemyCard.GetComponent<Card>().cardAtk)
        {
            Debug.Log("IT'S A TIE!");
            tieGo.SetActive(true);
            Invoke("LoseScreen", 2f);
        }
    }

    void Shield()
    {
        Debug.Log("Shield stat");
        if (playerCard.GetComponent<Card>().cardShield > enemyCard.GetComponent<Card>().cardShield)
        {
            Invoke("WinScreen", 2f);
        }
        if (enemyCard.GetComponent<Card>().cardShield > playerCard.GetComponent<Card>().cardShield)
        {
            Invoke("LoseScreen", 2f);
        }
        if (playerCard.GetComponent<Card>().cardAtk == enemyCard.GetComponent<Card>().cardAtk)
        {
            Debug.Log("IT'S A TIE!");
            tieGo.SetActive(true);
            Invoke("LoseScreen", 2f);
        }
    }

    void Health()
    {
        Debug.Log("Health stat");
        if (playerCard.GetComponent<Card>().cardHealth > enemyCard.GetComponent<Card>().cardHealth)
        {
            Invoke("WinScreen", 2f);   
        }
        if (enemyCard.GetComponent<Card>().cardHealth > playerCard.GetComponent<Card>().cardHealth)
        {
            Invoke("LoseScreen", 2f);
        }
        if (playerCard.GetComponent<Card>().cardAtk == enemyCard.GetComponent<Card>().cardAtk)
        {
            Debug.Log("IT'S A TIE!");
            tieGo.SetActive(true);
            Invoke("LoseScreen", 2f);
        }
    }

    void WinScreen()
    {
        SceneManager.LoadScene("WinScreen");
    }

    void LoseScreen()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
