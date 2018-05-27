using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour
{
    float startingScreenPos;
    float endingScreenPos;
    public float length;
    public float powerSensitivity = 0.05f;
    public Rigidbody ball;
    public Slider powerSlider;
    private int strokeTotal = 0;
    public Text strokeText;
    // Use this for initialization
    void Start()
    {
        ball = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (powerSlider != null)
        {
            powerSlider.value = length; // set the power slider to the value of the power of the shot

        }


        if (Input.GetMouseButtonDown(0) == true)
        {
            startingScreenPos = Input.GetAxis("Mouse Y");

        }

        if (Input.GetMouseButton(0) == true)
        {
            endingScreenPos -= Input.GetAxis("Mouse Y") * powerSensitivity;
            length = Mathf.Clamp(startingScreenPos - endingScreenPos, 0f, 1f);
        }

        if (Input.GetMouseButtonUp(0) == true)
        {

            ball.AddForce(new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z) * length, ForceMode.Impulse);
            //print(ball.gameObject.transform.forward * lenght);
            endingScreenPos = 0f;
            length = 0f;
            strokeTotal++;
            if (strokeText != null)
            {
                strokeText.text = strokeTotal.ToString();
            }
        }
    }
}
