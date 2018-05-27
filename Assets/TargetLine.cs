using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLine : MonoBehaviour
{
    private LineRenderer _line;
    [SerializeField]
    private float _distance = 2f;
    public BallMovement ballMovement;

    private void Start()
    {
        _line = GetComponent<LineRenderer>();
        ballMovement = GetComponentInChildren<BallMovement>();
        //_line.SetVertexCount(3);
        _line.positionCount = 2;
    }

    private void Update()
    {
        //Ray ray = new Ray(transform.position, Vector3.forward);
        //RaycastHit hit;
       // if (Physics.Raycast(ray, out hit))
        {
            _line.SetPositions(new[] { transform.position, transform.position + (new Vector3(Camera.main.transform.forward.x,0, Camera.main.transform.forward.z) * ballMovement.length) });
        }
    }
}
