using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveWheels : MonoBehaviour
{
    public float movementForce = 500.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 blah = GetComponent<ConfigurableJoint>().axis;
        //GetComponent<ConfigurableJoint>().axis.Set(0.0f, blah.y, 0.0f);
        //Quaternion rotation = Quaternion.Euler(transform.rotation.eulerAngles);
        //GetComponent<ConfigurableJoint>().targetRotation.Set(rotation.x, rotation.y, rotation.z, rotation.w);
    }

    private void LateUpdate()
    {
        
    }
}
