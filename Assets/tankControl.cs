using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankControl : MonoBehaviour
{
    public float accelerationForce = 1.0f;
    bool facingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (facingRight)
            {
                facingRight = false;
                //gameObject.transform.
            }
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(-accelerationForce, 0.0f, 0.0f), ForceMode.Acceleration);
            Debug.Log("Left arrow pressed");
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(accelerationForce, 0.0f, 0.0f), ForceMode.Acceleration);
            Debug.Log("Right arrow pressed");
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {

        }
    }
}
