using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankControl : MonoBehaviour
{
    public float accelerationForce = 1.0f;
    public float movementSpeed = 5.0f;

    private float yRotation = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * Time.deltaTime * movementSpeed;
            Debug.Log("Left arrow pressed");
            //transform.eulerAngles = new Vector3(0, 180, 0);
            yRotation = 180.0f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("Right arrow pressed");
            transform.position += Vector3.right * Time.deltaTime * movementSpeed;
            //transform.eulerAngles = new Vector3(0, 0, 0);
            yRotation = 0.0f;
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Space pressed");
            transform.position += Vector3.up * Time.deltaTime * movementSpeed*2;
        }

        // Prevent rotation around X-azis and Z-axis, only allow Y-axis to be 0 or 180.
        Quaternion quaternionAngles = transform.rotation;
        quaternionAngles.eulerAngles = new Vector3(0, yRotation, 0);
        transform.rotation = quaternionAngles;

        // Prevent movement in Z-axis
        Vector3 position = transform.position;
        position.z = 0;
        transform.position = position;
    }
}
