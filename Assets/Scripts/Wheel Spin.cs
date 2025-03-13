using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WheelSpin : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float maxSpeed = 120f;
    [SerializeField] private GameObject hand;
    private Vector3 rotZ;
    private bool stop = false;
    [SerializeField] private bool startWatch = false;
    private float stopWatch = 0.0f;

    GameObject playerCard;
    GameObject enemyCard;

    private void Start()
    {
        playerCard = GameObject.FindGameObjectWithTag("Card");
        enemyCard = GameObject.FindGameObjectWithTag("Enemy");
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
                float sUp = 7f;
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
                    enemyCard.GetComponent<Card>().CardValueEnemy();
                    ZoneCheck();
                }
            }
        }
    }

    void ZoneCheck()
    {
        if (hand.transform.eulerAngles.z <= 360f && transform.eulerAngles.z > 241f)
        {
            Debug.Log("Atk stat");
            if (playerCard.GetComponent<Card>().cardAtk > enemyCard.GetComponent <Card>().cardAtk)
            {
                Debug.Log("Player Wins");
            }
            else
            {
                Debug.Log("The Enemy Wins");
            }
        }

        if (hand.transform.eulerAngles.z <= 241f && hand.transform.eulerAngles.z > 119f)
        {
            Debug.Log("Shield stat");
            if (playerCard.GetComponent<Card>().cardShield > enemyCard.GetComponent<Card>().cardShield)
            {
                Debug.Log("Player Wins");
            }
            else
            {
                Debug.Log("The Enemy Wins");
            }
        }

        if (hand.transform.eulerAngles.z <= 119f && hand.transform.eulerAngles.z > 0f)
        {
            Debug.Log("Health stat");
            if (playerCard.GetComponent<Card>().cardHealth > enemyCard.GetComponent<Card>().cardHealth)
            {
                Debug.Log("Player Wins");
            }
            else
            {
                Debug.Log("The Enemy Wins");
            }
        }
    }
}
