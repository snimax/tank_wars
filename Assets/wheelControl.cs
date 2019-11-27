using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheelControl : MonoBehaviour
{
    public float movementForce = 400.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 leftForce = transform.TransformVector(new Vector3(0.0f, 0.0f,movementForce));
            //Debug.DrawRay(transform.position, leftForce);
            //Debug.DrawRay(new Vector3(0.0f, 0.0f), leftForce);
            GetComponent<Rigidbody>().AddRelativeTorque(0.0f, 0.0f, movementForce);
            Debug.Log("Left " + GetComponent<Rigidbody>().angularVelocity.magnitude);
            //GetComponent<Rigidbody>().AddForce(transform.localToWorldMatrix * leftForce);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 rightForce = transform.TransformVector(new Vector3(0.0f, 0.0f,-movementForce));
            //Debug.DrawRay(transform.position, rightForce);
            //Debug.DrawRay(new Vector3(0.0f, 0.0f), rightForce);
            GetComponent<Rigidbody>().AddRelativeTorque(0.0f, 0.0f, -movementForce);
            Debug.Log("Right " + GetComponent<Rigidbody>().angularVelocity.magnitude);
            //GetComponent<Rigidbody>().AddForce(transform.localToWorldMatrix * rightForce);
        }
    }
}
