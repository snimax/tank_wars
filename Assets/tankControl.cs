using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankControl : MonoBehaviour
{
    public float accelerationForce = 1.0f;
    public float movementForce = 600.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        /*if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 leftForce = transform.TransformVector(new Vector3(-movementForce, 0.1f * movementForce, 0.0f));
            Debug.DrawRay(transform.position, leftForce);
            Debug.DrawRay(new Vector3(0.0f, 0.0f), leftForce);
            GetComponent<Rigidbody>().AddForce(transform.localToWorldMatrix * leftForce);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 rightForce = transform.TransformVector(new Vector3(movementForce, 0.1f * movementForce, 0.0f));
            Debug.DrawRay(transform.position, rightForce);
            Debug.DrawRay(new Vector3(0.0f, 0.0f), rightForce);
            GetComponent<Rigidbody>().AddForce(transform.localToWorldMatrix * rightForce);
        }*/

        /*if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Space pressed");
            GetComponent<Rigidbody>().AddForce(0.0f, 10 * movementForce, 0.0f);
        }*/
    }

}
