using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelSpin : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float maxSpeed = 120f;
    [SerializeField] private float increase = 4f;
    [SerializeField] private float angle;
    [SerializeField] private GameObject hand;
    private float timer3 = 0f;
    private Vector3 rotZ;
    private bool stop = false;
    private Rigidbody2D rbody;
    // Start is called before the first frame update

    private void FixedUpdate()
    {
        timer3 += Time.deltaTime;
        rotZ  = new Vector3(0,0, speed * Time.deltaTime);
        if (hand.transform.rotation.z >= -360)
        {
            //RESET ROTATION BACK TO 0
        }

        if ( speed  < maxSpeed)
        {
            speed += Time.deltaTime;
        }
       // Debug.Log(hand.transform.eulerAngles.z);

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
            BigSpin();
        }

        if (!stop) 
        {
            hand.transform.eulerAngles -= rotZ;
            angle = hand.transform.eulerAngles.z;
        }
    }

    void BigSpin()
    {
        timer3 = 0;
        if (timer3 >= 3f && timer3 <= 4f)
        {
            speed += increase;
        }

        if (timer3 > 5f)
        {
            speed -= increase;
            if (speed <= 0f)
            {
                speed = 0f;
                rotZ = Vector3.zero;
            }
        }
    }


    void ZoneCheck()
    {
        if (hand.transform.eulerAngles.z <= 360f && transform.eulerAngles.z > 241f)
        {
            Debug.Log("Atk stat");
        }

        if (hand.transform.eulerAngles.z <= 241f && hand.transform.eulerAngles.z > 119f)
        {
            Debug.Log("Shield stat");
        }

        if (hand.transform.eulerAngles.z <= 119f && hand.transform.eulerAngles.z > 0f)
        {
            Debug.Log("Health stat");
        }
    }
}
