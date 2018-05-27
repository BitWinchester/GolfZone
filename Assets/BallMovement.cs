using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    float startingScreenPos;
    float endingScreenPos;
    public float length;
    public float powerSensitivity = 0.1f;
    public Rigidbody ball;
    // Use this for initialization
    void Start()
    {
        ball = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //print(Input.GetAxis("Mouse Y"));

        if (Input.GetMouseButtonDown(0) == true)
        {
            startingScreenPos = Input.GetAxis("Mouse Y");
            
        }

        if (Input.GetMouseButton(0) == true)
        {
            endingScreenPos -= Input.GetAxis("Mouse Y") * powerSensitivity;
            length = startingScreenPos - endingScreenPos;
        }

        if (Input.GetMouseButtonUp(0) == true)
        {
           
            ball.AddForce(new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z) * length, ForceMode.Impulse);
            //print(ball.gameObject.transform.forward * lenght);
            endingScreenPos = 0f;
            length = 0f;
        }
    }
}
