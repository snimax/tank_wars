using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankControl : MonoBehaviour
{
    public float accelerationForce = 1.0f;
    public float movementForce = 400.0f;

    private bool lookingLeft = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 leftForce = transform.TransformVector(new Vector3(movementForce, 0.0f, 0.0f));
            Debug.DrawRay(transform.position, leftForce);
            GetComponent<Rigidbody>().AddForce(leftForce);

            if (!lookingLeft)
            {
                transform.Rotate(new Vector3(0.0f, 180.0f, 0.0f), Space.Self);
                lookingLeft = true;
            }
                
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 rightForce = transform.TransformVector(new Vector3(movementForce, 0.0f, 0.0f));
            Debug.DrawRay(transform.position, rightForce);
            GetComponent<Rigidbody>().AddForce(rightForce);
            if (lookingLeft) {
                transform.Rotate(new Vector3(0.0f, 180.0f, 0.0f), Space.Self);
                lookingLeft = false;
            }
            
        }
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Space pressed");
            GetComponent<Rigidbody>().AddForce(0.0f, 10 * movementForce, 0.0f);
        }
        

        // Prevent rotation around X-azis and Z-axis, only allow Y-axis to be 0 or 180.
        Quaternion quaternionAngles = transform.rotation;
        
        //quaternionAngles.eulerAngles = new Vector3(0, yRotation, quaternionAngles.eulerAngles.z);
        //transform.rotation = quaternionAngles;

        // Prevent movement in Z-axis
        Vector3 position = transform.position;
        position.z = 0;
        transform.position = position;
    }

}
