using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonControl : MonoBehaviour
{
    public float turretSpeed = 2.0f;
    public float shotCharge = 0.0f;
    private float chargeStart;
    public GameObject cannonBall;
    public float shotForce = 100.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            
            Vector3 rotation = transform.localRotation.eulerAngles;
            rotation.z += turretSpeed;
            if (rotation.z <= 180.0f)
            {
                transform.Rotate(0.0f, 0.0f, turretSpeed, Space.Self);
            }
            
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            Vector3 rotation = transform.localRotation.eulerAngles;
            rotation.z -= turretSpeed;
            if (rotation.z >= 0.0f)
            {
                transform.Rotate(0.0f, 0.0f, -turretSpeed, Space.Self);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            chargeStart = Time.time;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            float shotCharge = Time.time - chargeStart;
            shotCharge = shotCharge > 1 ? 1 : shotCharge;
            Quaternion rotation = transform.localRotation;
            Vector3 pos = transform.position;
            GameObject shot = Instantiate(cannonBall, pos, rotation);
            shot.transform.Translate(0.5f, 0.0f, 0.0f, Space.Self);
            shot.GetComponent<Rigidbody>().AddRelativeForce(shotForce*shotCharge, 0.0f, 0.0f);
            Debug.Log(shotCharge);

        }
    }
}
