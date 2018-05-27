using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject followObject;
    public Transform cameraContainer;
    private Vector3 offset;
    public float scrollSpeed = 4f;
    private float X;
    private float Y;
    private float distanceToFollowObject;
    private Vector3 headingToFollowObject;
    


    // Use this for initialization
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = cameraContainer.position - followObject.transform.position;
    }

    void LateUpdate()
    {
        headingToFollowObject = followObject.transform.position - gameObject.transform.position;
        distanceToFollowObject = Vector3.Distance(gameObject.transform.position, followObject.transform.position);
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        //cameraContainer.position = followObject.transform.position;

        cameraContainer.position = new Vector3(Mathf.Lerp(cameraContainer.position.x, followObject.transform.position.x, 0.2f),
                                 Mathf.Lerp(cameraContainer.position.y, followObject.transform.position.y, 0.2f),
                                 Mathf.Lerp(cameraContainer.position.z, followObject.transform.position.z,0.2f));

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
           // transform.Translate(Vector3.forward * -scrollSpeed);
            Camera.main.transform.position = Vector3.Lerp(gameObject.transform.position, followObject.transform.position, Time.deltaTime * scrollSpeed);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {

            //transform.Translate(Vector3.forward * scrollSpeed);
            Camera.main.transform.position = Vector3.Lerp(gameObject.transform.position, gameObject.transform.position - headingToFollowObject, Time.deltaTime * scrollSpeed);
        }

       // if (Input.GetMouseButton(2))
        {

            cameraContainer.Rotate(0f, Input.GetAxis("Mouse X") * scrollSpeed, 0f, Space.World);
            ///Add this line back in if you want the camera to pan up and down
           // cameraContainer.Rotate(-Input.GetAxis("Mouse Y") * scrollSpeed, 0f, 0f, Space.Self);

        }
    }
}
