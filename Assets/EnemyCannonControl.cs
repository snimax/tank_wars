using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCannonControl : MonoBehaviour
{
    public float turretSpeed = 2.0f;
    public float shotCharge = 0.0f;
    private float chargeStart;
    public GameObject cannonBall;
    public float shotForce = 100.0f;

    public float stoppingDistance = 7.0f;
    public float retreatDistance = 4.0f;
    public Transform playerTank;
    private float startShotTime = 0.0f;
    public float fireTimeInterval = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerTank = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        // Save for human enemy player?
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
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
            shot.GetComponent<Rigidbody>().AddRelativeForce(shotForce * shotCharge, 0.0f, 0.0f);
            Debug.Log(shotCharge);

        }
        */



        if (Vector3.Distance(transform.position, playerTank.position) < stoppingDistance)
        {
            // we are in sight
            if (Vector3.Distance(transform.position, playerTank.position) > stoppingDistance - 1)
            {
                shotCharge = 0.75f;
            }
            else if (Vector3.Distance(transform.position, playerTank.position) > stoppingDistance - 2)
            {
                shotCharge = 0.5f;
            }
            else if (Vector3.Distance(transform.position, playerTank.position) > stoppingDistance - 3)
            {
                shotCharge = 0.25f;
            }
            else
            {
                shotCharge = 0.5f;
            }
            if(Time.time - startShotTime > fireTimeInterval)
            {
                FireCannon();
            }
        }

    }

    void FireCannon()
    {
        Quaternion rotation = transform.localRotation;
        Vector3 pos = transform.position;
        GameObject shot = Instantiate(cannonBall, pos, rotation);
        shot.transform.Translate(0.5f, 0.0f, 0.0f, Space.Self);
        shot.GetComponent<Rigidbody>().AddRelativeForce(shotForce * shotCharge, 0.0f, 0.0f);
        Debug.Log(shotCharge);

        startShotTime = Time.time;
    } 
}
