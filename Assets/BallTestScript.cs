using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTestScript : MonoBehaviour
{

    public Rigidbody rb;
    public float force = 200f;
    public GameObject spawnLoc;

    private Quaternion initRotation;
    // Use this for initialization
    void Start()
    {
        rb = GetComponentInChildren<Rigidbody>();
        Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Confined;
        Cursor.lockState = CursorLockMode.Locked;
        initRotation = transform.rotation;
        print(initRotation);

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 ballforce = gameObject.transform.forward * force;

        if (Input.GetKeyDown(KeyCode.E))
        {
            rb.AddForce(ballforce, ForceMode.Impulse);
            //rb.AddTorque(ballforce);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            rb.Sleep();
            gameObject.transform.rotation = initRotation;
            gameObject.transform.position = spawnLoc.transform.position;
        }
    }
}
