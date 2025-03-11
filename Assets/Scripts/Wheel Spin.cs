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
    // Start is called before the first frame update

    private void FixedUpdate()
    {
        rotZ  = new Vector3(0,0, speed * Time.deltaTime);
        if (hand.transform.rotation.z >= -360)
        {
            //RESET ROTATION BACK TO 0
        }

        if ( speed  < maxSpeed && !stop)
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
            startWatch = true;
        }

        if (!stop) 
        {
            hand.transform.eulerAngles -= rotZ;
        }
        if (startWatch)
        {
            stopWatch += Time.deltaTime;
            Debug.Log(stopWatch);
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
